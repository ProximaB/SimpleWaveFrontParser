using System;
using Xunit;
using WaveFrontParser.Hendler;
using System.IO;

namespace WaveFrontParserTests
{
    public class WaveFrontParserTests
    {
        public class LoadObjFileHendlerTests
        {
            static string path = "localFile";
            LoadObjFileHendler fileHendler = new LoadObjFileHendler( path );

            [Fact]
            public void LoadObjFileHendler_AddingCurrentDirectoryPathPrefixToGivenFileName_PathExist()
            {
                var Modifiedpath = fileHendler.objFilePath;
                var directory = Modifiedpath.TrimEnd(path.ToCharArray());

                Assert.True(Directory.Exists(directory));

            }
        }
        

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
