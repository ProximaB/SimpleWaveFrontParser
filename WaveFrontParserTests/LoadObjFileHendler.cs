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
        

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
