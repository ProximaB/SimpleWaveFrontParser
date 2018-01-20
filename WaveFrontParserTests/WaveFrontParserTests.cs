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
                static string testVertexs = "v 1.000000 -1.000000 -1.000000\r\n"
                                   + "v 1.000000 -1.000000 1.000000 \r\n";
                //mock
                ILoadObjFileHandler obj = new LoadObjFileHandlerMock(testVertexs);
              
                [Fact]
                public void LookForVertexes_IsFindingVertexesFromRawText_FoundProperVertexs()
                {
                    SimpleWaveFrontService waveService = new SimpleWaveFrontService(obj);

                    var vertexs = waveService.LookForVertexs();

                    bool CompareResult = (util.Compare(vertexs[0], new Vertex() { XAxis = 1, YAxis = -1, ZAxis = -1 }) == 1 
                                       && util.Compare(vertexs[1], new Vertex() { XAxis = 1, YAxis = -1, ZAxis =  1 }) == 1);

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

                        var textVerts = waveService.LookForTextureVertex();

                        bool CompareResult =
                            (util.Compare(textVerts[0], new TextureVertex() { XAxis = 0.5, YAxis = 0.2 }) == 1)
                            && (util.Compare(textVerts[1], new TextureVertex() { XAxis = 0.35, YAxis = 0.4 }) == 1);

                        Assert.True(CompareResult);
                    }
                }

            }
        }
    }
}
