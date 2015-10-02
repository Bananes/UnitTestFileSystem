using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class Directory : File
    {
        public List<File> Fichiers = new List<File>();

        public Directory(string Nom, Directory parent)
            : base(Nom, parent)
        { }

        public Directory(string Nom)
            : base(Nom)
        {
            this.Nom = Nom;
            path = Nom;
        }

        public bool createNewFile(string name)
        {
            bool create = false;
            if (this.canWrite())
            {
                foreach (File fichier in this.Fichiers)
                {
                    if (fichier.Nom == name)
                    {
                        Console.WriteLine("Ce fichier existe déjà");
                        create = true;
                    }
                }
                if (create != true)
                {
                    File fichier = new File(name, (Directory)this);
                }
                return create = true;
            }
            else
            {
                Console.WriteLine("Permissions insufissantes :{");
                return create;
            }
        }
        public List<File> ls()
        {
            return this.Fichiers;
        }

        public bool renameTo(string name, string newName)
        {
            bool change = false;
            if (this.canWrite())
            {
                    foreach (File fichier in this.Fichiers)
                    {
                        if (newName == fichier.Nom)
                        {
                            Console.WriteLine(newName+" est déjà existant...");
                            return change;
                        }
                        
                    }
                    foreach (File fichier in this.Fichiers)
                    {
                            if (fichier.Nom == name)
                            {
                                fichier.Nom = newName;
                                return change = true;
                            }
                    }
                    if (change == false)
                    {
                        Console.WriteLine("Impossible de renommer, fichier \""+name+"\" inexistant");
                    }
                return change;
            }
            else
            {
                Console.WriteLine("Permissions insufissantes :{");
                return change;
            }
        }

        public override File cd(string name)
        {
            foreach (File file in this.Fichiers)
            {
                if(name == file.Nom)
                {
                    return file;
                }
            }
            Console.WriteLine("Répertoire inexistant...");
            return this;
        }

        public bool delete(string name)
        {
            bool destroy = false;
            if (this.canWrite())
            {
                foreach (File fichier in Fichiers)
                {
                    if (name == fichier.Nom)
                    {
                        Fichiers.Remove(fichier);
                        return destroy = true;
                    }
                }
                if (destroy == false)
                {
                    Console.WriteLine("Fichier inexistant...");
                    
                }
                return destroy;
            }
            else
            {
                Console.WriteLine("Permissions insufissantes :{");
                return destroy;
            }
        }

        public List<File> search(string name)
        {
            List<File> list = new List<File>();
            if (this.canRead())
            {
                this.Fichiers.ForEach(delegate(File child)
                {
                    if (name == child.Nom)
                    {
                        list.Add(child);
                    }
                    Directory enfant;
                    if (child.isDirectory())
                    {
                        enfant = (Directory)child;
                        list = enfant.search(name);
                    }
                });
            }
            return list;
        }
    }
}

