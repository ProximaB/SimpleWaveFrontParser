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

                List<Vertex> vertexs = new List<Vertex>();
                SimpleWaveFrontService waveService = new SimpleWaveFrontService();

                [Fact]
                public void LookForVertexes_IsFindingVertexesFromRawText_FoundProperVertexs()
                {
                    waveService.LookForVertexs(obj, vertexs);

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

                    List<Normal> normals = new List<Normal>();
                    SimpleWaveFrontService waveService = new SimpleWaveFrontService();

                    [Fact]
                    public void LookForNomals_IsFindingNormalsFromRawText_FoundProperNormals()
                    {
                        waveService.LookForNormals(obj, normals);

                        bool CompareResult =
                            (util.Compare(normals[0], new Normal() { XAxis = 0, YAxis = -1, ZAxis = 0 }) == 1)
                            && (util.Compare(normals[1], new Normal() { XAxis = 0, YAxis = 1, ZAxis = 0 }) == 1);

                        Assert.True(CompareResult);
                    }
                }

            }
        }
    }
}
