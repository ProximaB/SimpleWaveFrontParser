using System;
using Xunit;
using WaveFrontParser.Hendler;
using WaveFrontParser.Interface;
using WaveFrontParser.Service;
using System.IO;
using WaveFrontParserTests.Hendler;
using WaveFrontParser.Model;
using System.Collections.Generic;
using WaveFrontParser.Helper;

namespace WaveFrontParserTests
{
    public class WaveFrontParserTests
    {
        public class LoadObjFileHendlerTests
        {
            static string fileName = "localFile";
            LoadObjFileHendler fileHendler = new LoadObjFileHendler(fileName);

            [Fact]
            public void LoadObjFileHendler_AddingCurrentDirectoryPathPrefixToGivenFileName_DirectoryExist()
            {
                var Modifiedpath = fileHendler.FilePath;

                var directory = Modifiedpath.TrimEnd(fileName.ToCharArray());
                var IsDirectoryExist = Directory.Exists(directory);

                Assert.True(IsDirectoryExist);

            }

            [Fact]
            public void LoadObjFileHendler_IsBackslashAddedBetweenCurrentDIrectoryAndLocalFileName_FoundForwardSlash()
            {
                var Modifiedpath = fileHendler.FilePath; Modifiedpath.TrimEnd(fileName.ToCharArray());
                var CharBeforeLocalFileName = Modifiedpath.Substring(Modifiedpath.LastIndexOf(@"\"), 1);

                Assert.Equal(@"\", CharBeforeLocalFileName);

            }

        }

        public class SimpleWaveFrontServiceTests
        {
            public class LookForVertexsTests
            {
                CompareObjects hepl = new CompareObjects();
                static string testVertexs = "1.000000 -1.000000 -1.000000v "
                                   + "1.000000 -1.000000 1.000000v ";
                //mock
                ILoadObjFileHendler obj = new LoadObjFileHendlerMock(testVertexs);

                List<Vertex> vertexs = new List<Vertex>();
                SimpleWaveFrontService waveService = new SimpleWaveFrontService();

                [Fact]
                public void LookForVertexes_IsFindingVertexesFormRawText_FoundProperVertexs()
                {
                    bool isProper = false;
                    waveService.LookForVertexs(obj, vertexs);

                    if (hepl.Compare(vertexs[0], new Vertex() { XAxis = 1, YAxis = -1, ZAxis = -1 }) +
                        hepl.Compare(vertexs[1], new Vertex() { XAxis = 1, YAxis = -1, ZAxis = 1 }) == 2)
                    {
                        isProper = true; 
                    }

                    Assert.True(isProper);
                }           

            }
        }
    }
}
