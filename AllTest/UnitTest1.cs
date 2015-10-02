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
        public Directory patate;
        public File samFichier;

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
        public void mkdir()
        {
            Assert.IsTrue(repCourant.mkdir("benjaminTourman"));
        }

        [TestMethod]
        public void search()
        {
            lol = (Directory)repCourant.cd("lol");
            lol.mkdir("truc");
            lol.getParent();
            //Assert.AreEqual(lol.search("truc").Count, lol.cd("lol").l);
        }

        [TestMethod]
        public void Notmkdir()
        {
            repCourant.chmod(4);
            Assert.IsFalse(repCourant.mkdir("benjaminTourman"));
        }

        [TestMethod]
        public void createNewFile()
        {
            Assert.IsTrue(repCourant.createNewFile("lol"));
        }

        [TestMethod]
        public void NotcreateNewFile()
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
