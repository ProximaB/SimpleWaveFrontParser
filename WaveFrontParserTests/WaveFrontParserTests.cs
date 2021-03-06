using System;
using Xunit;
using WaveFrontParser.Handler;
using WaveFrontParser.Interface;
using WaveFrontParser.Service;
using System.IO;
using WaveFrontParser.Tests.Handler;
using WaveFrontParser.Model;
using System.Collections.Generic;
using WaveFrontParser.Helper;

namespace WaveFrontParser.Tests
{
    public class WaveFrontParserTests
    {
        public class LoadObjFileHandlerTests
        {
            static string fileName = "localFile";
            LoadObjFileHandler fileHandler = new LoadObjFileHandler(fileName);

            [Fact]
            public void LoadObjFileHandler_AddingCurrentDirectoryPathPrefixToGivenFileName_DirectoryExist()
            {
                var Modifiedpath = fileHandler.FilePath;

                var directory = Modifiedpath.TrimEnd(fileName.ToCharArray());
                var IsDirectoryExist = Directory.Exists(directory);

                Assert.True(IsDirectoryExist);

            }

            [Fact]
            public void LoadObjFileHandler_IsBackslashAddedBetweenCurrentDIrectoryAndLocalFileName_FoundForwardSlash()
            {
                var Modifiedpath = fileHandler.FilePath; Modifiedpath.TrimEnd(fileName.ToCharArray());
                var CharBeforeLocalFileName = Modifiedpath.Substring(Modifiedpath.LastIndexOf(@"\"), 1);

                Assert.Equal(@"\", CharBeforeLocalFileName);

            }

        }

        public class SimpleWaveFrontServiceTests
        {
            public class LookForVertexsTests
            {
                CompareObjects util = new CompareObjects();
                static string testVertexs = "v 45.000000 -1.000000 -1.000000\r\n"
                                   + "v 1.000000 -22.000000 1.000000 \r\n";
                //mock
                ILoadObjFileHandler obj = new LoadObjFileHandlerMock(testVertexs);
              
                [Fact]
                public void LookForVertexes_IsFindingVertexesFromRawText_FoundProperVertexs()
                {
                    SimpleWaveFrontService waveService = new SimpleWaveFrontService(obj);

                    var vertexs = waveService.LookForVertexs();

                    bool CompareResult = (util.Compare(vertexs[0], new Vertex() { XAxis = 45, YAxis = -1, ZAxis = -1 }) == 1 
                                       && util.Compare(vertexs[1], new Vertex() { XAxis = 1, YAxis = -22, ZAxis =  1 }) == 1);

                    Assert.True(CompareResult);
                }

                public class LookForNormals
                {
                    CompareObjects util = new CompareObjects();

                    static string testNormals = "vn 0.000000 -1.000000 0.000000 \n\r"
                                            + "vn 0.000000 1.000000 0.000000\n\r";
                    //mock
                    ILoadObjFileHandler obj = new LoadObjFileHandlerMock(testNormals);

                    [Fact]
                    public void LookForNomals_IsFindingNormalsFromRawText_FoundProperNormals()
                    {
                        SimpleWaveFrontService waveService = new SimpleWaveFrontService(obj);

                        var normals = waveService.LookForNormals();

                        bool CompareResult =
                            (util.Compare(normals[0], new Normal() { XAxis = 0, YAxis = -1, ZAxis = 0 }) == 1)
                            && (util.Compare(normals[1], new Normal() { XAxis = 0, YAxis = 1, ZAxis = 0 }) == 1);

                        Assert.True(CompareResult);
                    }
                }

                public class LookForTextureVertex
                {
                    CompareObjects util = new CompareObjects();

                    static string testTexVertexs = "vt 0.5 0.2\n\r"
                                                    + "vt 0.35 0.4\n\r";
                    //mock
                    ILoadObjFileHandler obj = new LoadObjFileHandlerMock(testTexVertexs);

                    [Fact]
                    public void LookForTextureVertex_IsFindingTexVertexFromRawText_FoundProperTextVertexs()
                    {
                        SimpleWaveFrontService waveService = new SimpleWaveFrontService(obj);

                        var texVerts = waveService.LookForTextureVertex();

                        bool CompareResult =
                            (util.Compare(texVerts[0], new TextureVertex() { XAxis = 0.5f, YAxis = 0.2f }) == 1)
                            && (util.Compare(texVerts[1], new TextureVertex() { XAxis = 0.35f, YAxis = 0.4f }) == 1);

                        Assert.True(CompareResult);
                    }
                }

                public class LookForFacesIndiciesType1
                {
                    CompareObjects util = new CompareObjects();

                    static string testFaces = "f 6/1/1 4/2/1 0/3/1\n\r"
                                                +"f 1/1/1 3/3/1 4/4/1\n\r";
                    //mock
                    ILoadObjFileHandler obj = new LoadObjFileHandlerMock(testFaces);

                    [Fact]
                    public void LookForFaces_IsFindingFaces1TypeFromRawText_FoundProperFaces()
                    {
                        SimpleWaveFrontService waveService = new SimpleWaveFrontService(obj);

                        var facesIndicies = waveService.LookForFaces(1);

                        bool CompareResult =
                            (util.Compare(facesIndicies[0], new Face()
                            {
                                VertIndicies = new List<int>() { 6, 4, 0 },
                                NormIndicies = new List<int>() { 1, 2, 3 },
                                TexIndicies = new List<int>() { 1, 1, 1 },
                            }) == 1)
                        &&
                            (util.Compare(facesIndicies[1], new Face()
                            {
                                VertIndicies = new List<int>() { 1, 3, 4 },
                                NormIndicies = new List<int>() { 1, 3, 4 },
                                TexIndicies = new List<int>() { 1, 1, 1 },
                            }) == 1);

                        Assert.True(CompareResult);
                    }
                }

                public class LookForFacesIndiciesType2
                {
                    CompareObjects util = new CompareObjects();

                    static string testFaces = "f 6 4 0\n\r"
                                                + "f 1 3 4\n\r";
                    //mock
                    ILoadObjFileHandler obj = new LoadObjFileHandlerMock(testFaces);

                    [Fact]
                    public void LookForFaces_IsFindingFaces2TypeFromRawText_FoundProperFaces()
                    {
                        SimpleWaveFrontService waveService = new SimpleWaveFrontService(obj);

                        var facesIndicies = waveService.LookForFaces(2);

                        bool CompareResult =
                            (util.Compare(facesIndicies[0], new Face()
                            {
                                VertIndicies = new List<int>() { 6, 4, 0 },
                            }) == 1)
                        &&
                            (util.Compare(facesIndicies[1], new Face()
                            {
                                VertIndicies = new List<int>() { 1, 3, 4 },
                            }) == 1);

                        Assert.True(CompareResult);
                    }
                }

            }
        }
    }
}
