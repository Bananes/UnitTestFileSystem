using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem;

namespace AllTest
{
    [TestClass]
    public class UnitTest1
    {
        public Directory repCourant;
        public Directory lol;
        public Directory banane;
        public File samFichier = new File("samFichier");

        [TestInitialize]
        public void SetUp()
        {
            repCourant = new Directory("C:");
            repCourant.chmod(7);
            repCourant.mkdir("lol");
            repCourant.mkdir("banane");
            repCourant.mkdir("patate");
            repCourant.createNewFile("samFichier");
        }

        [TestMethod]
        public void getName()
        {
            Assert.AreEqual(repCourant.Nom, "C:");
            repCourant = (Directory)repCourant.cd("banane");
            Assert.AreEqual(repCourant.Nom, "banane");
        }

        [TestMethod]
        public void getParent()
        {
            lol = (Directory)repCourant.cd("lol");
            Assert.AreEqual(repCourant, lol.getParent());
        }

        [TestMethod]
        public void getParentRoot()
        {
            Assert.IsNull(repCourant.parent);
        }

        [TestMethod]
        public void mkdir()
        {
            repCourant.mkdir("benjaminTourman");
            Assert.AreEqual(repCourant.cd("benjaminTourman").Nom, "benjaminTourman");
        }

        [TestMethod]
        public void Notmkdir()
        {
            repCourant.mkdir("benjaminTourman");
            Assert.AreNotEqual(repCourant.cd("benjaminTourman").Nom, "benjamin");
        }

        [TestMethod]
        public void mkdirPerm()
        {
            Assert.IsTrue(repCourant.mkdir("benjaminTourman"));
        }

        [TestMethod]
        public void mkdirNotPerm()
        {
            repCourant.chmod(4);
            Assert.IsFalse(repCourant.mkdir("benjaminTourman"));
        }

        [TestMethod]
        public void search()
        {
            repCourant.cd("lol");
            lol = (Directory)repCourant;
            lol.createNewFile("truc");
            lol.getParent();
            lol.getParent();
            Assert.AreEqual(lol.search("truc").Count, 1);
        }

        [TestMethod]
        public void createNewFile()
        {   
            repCourant.createNewFile("truc");
            Assert.AreEqual(repCourant.cd("truc").Nom, "truc");
        }

        [TestMethod]
        public void NotcreateNewFile()
        {
            repCourant.createNewFile("truc");
            Assert.AreNotEqual(repCourant.cd("truc").Nom, "tru");
        }

        [TestMethod]
        public void createNewFilePerm()
        {
            Assert.IsTrue(repCourant.createNewFile("lol"));
        }

        [TestMethod]
        public void createNewFileNotPerm()
        {
            repCourant.chmod(4);
            Assert.IsFalse(repCourant.createNewFile("lol"));
        }

        [TestMethod]
        public void ls()
        {
            Assert.AreEqual(repCourant.ls().Count, 4);
        }

        [TestMethod]
        public void chmod()
        {
            lol = (Directory)repCourant.cd("lol");
            lol.chmod(7);
            Assert.AreEqual(lol.permission, 7);
        }

        [TestMethod]
        public void cd()
        {
            lol = (Directory)repCourant.Fichiers[0];
            Assert.AreEqual(repCourant.cd("lol"), lol); 
        }

        [TestMethod]
        public void cdInFile()
        {
            Assert.AreEqual(samFichier.cd("nimportequoi"), samFichier);
        }

        [TestMethod]
        public void getPath()
        {
            repCourant = (Directory)repCourant.cd("lol");
            Assert.AreEqual(repCourant.getPath(), "C:/lol");
        }

        [TestMethod]
        public void getRoot()
        {
            repCourant = (Directory)repCourant.cd("lol");
            Assert.AreEqual(repCourant.getRoot().Nom, "lol");
        }

        [TestMethod]
        public void getRootC()
        {
            Assert.AreEqual(repCourant.getRoot().Nom, "C:");
        }

        [TestMethod]
        public void renamePerm()
        {
            Assert.IsTrue(repCourant.renameTo("lol", "I Don't know"));
        }

        [TestMethod]
        public void renameNotPerm()
        {
            repCourant.chmod(4);
            Assert.IsFalse(repCourant.renameTo("lol", "I Don't know"));
        }

        [TestMethod]
        public void IsRename()
        {
            Assert.IsTrue(repCourant.renameTo("lol", "test"));//Rename dir
            Assert.IsTrue(repCourant.renameTo("samFichier", "truc"));//Rename file
        }

        [TestMethod]
        public void IsNotRename()
        {
            Assert.IsFalse(repCourant.renameTo("truc", "banane")); //Rename dir
            Assert.IsFalse(repCourant.renameTo("samFichier", "lol"));//Rename file

            Assert.IsFalse(repCourant.renameTo("benjamin", "tourman"));//rename avec un nom non existant
        }

        [TestMethod]
        public void DeletePerm()
        {
            Assert.IsTrue(repCourant.delete("lol"));
        }

        [TestMethod]
        public void DeleteNotPerm()
        {
            repCourant.chmod(4);
            Assert.IsFalse(repCourant.delete("lol"));
        }

        [TestMethod]
        public void IsDelete()
        {
            Assert.IsTrue(repCourant.delete("lol"));
        }

        [TestMethod]
        public void IsNotDelete()
        {
            Assert.IsFalse(repCourant.delete("lo"));
        }

        [TestMethod]
        public void IsDirectory()
        {
            Assert.IsTrue(repCourant.isDirectory());
        }

        [TestMethod]
        public void IsNotDirectory()
        {
            samFichier = repCourant.cd("samFichier");
            Assert.IsFalse(samFichier.isDirectory());
        }

        [TestMethod]
        public void IsFile()
        {
            samFichier = repCourant.cd("samFichier");
            Assert.IsTrue(samFichier.isFile());
        }

        [TestMethod]
        public void IsNotFile()
        {
            Assert.IsFalse(repCourant.isFile());
        }
    }
}
