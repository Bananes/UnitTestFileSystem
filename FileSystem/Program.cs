using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Oui je sais c'est pas C: mais j'm'embrouille moins comme ça
            Directory C = new Directory("C:");
            File Actuel = (Directory)C;
            commande(Actuel);
            
            
        }
        public static void commande(File Actuel)
        {
        Console.Write(Actuel.path + "> ");
        string commandes = Console.ReadLine();
        List<string> action = new List<string> (commandes.Split(' '));
               switch (action[0])
               {
                   case "path":
                       if (action.Count == 1)
                       {
                           Console.WriteLine(Actuel.getPath());
                       }
                       else
                       {
                           goto default;
                       }
                   break;
                   case "search":
                   if (action.Count == 2)
                   {
                       if (Actuel.isDirectory())
                       {
                           Directory dir = (Directory)Actuel;
                           var list = new List<File>();
                           if (dir.isDirectory())
                              list = dir.search(action[1]);
                           list.ForEach(delegate(File f)
                           {
                               Console.WriteLine("   found : " + f.GetType().ToString().Replace("FileSystem.", " ").Substring(0, 4) + "  " + f.path);
                           });
                       }
                       else
                       {
                           Console.WriteLine("Vous êtes dans un fichier");
                       }
                   }
                   else
                   {
                       goto default;
                   }  
                    break;
                   case "create":
                   if (action.Count == 2)
                   {
                       if (Actuel.isDirectory())
                       {
                           bool test = false;
                           Directory dir = (Directory)Actuel;
                           foreach (File fichier in dir.Fichiers)
                           {
                               if (fichier.Nom == action[1])
                               {
                                   Console.WriteLine("Ce fichier existe déjà");
                                   test = true;
                                   break;
                               }
                           }
                           if (test == false)
                           {
                               dir.createNewFile(action[1]);
                               Actuel = dir;
                           }
                       }
                       else
                       {
                           Console.WriteLine("Vous n'êtes pas dans un dossier");
                       }
                   }
                   else
                   {
                       goto default;
                   }  
                   break;
                   case "mkdir":
                   if (action.Count == 2)
                   {
                       if (Actuel.isDirectory())
                       {
                           bool test = false;
                           Directory dir = (Directory)Actuel;
                           foreach (File fichier in dir.Fichiers)
                           {
                               if (fichier.Nom == action[1])
                               {
                                   Console.WriteLine("Ce fichier existe déjà");
                                   test = true;
                                   break;
                               }
                           }
                           if (test == false)
                           {
                               dir.mkdir(action[1]);
                               Actuel = dir;
                           }
                       }
                       else
                       {
                           Console.WriteLine("Vous n'êtes pas dans un dossier");
                       }
                   }
                   else
                   {
                       goto default;
                   }  
                   break;
                   case "name":
                   if (action.Count == 1)
                   {
                       Console.WriteLine(Actuel.getName());
                   }
                   else
                   {
                       goto default;
                   }
                   break;
                   case "ls":
                   if (action.Count == 1)
                   {
                       if (Actuel.isDirectory())
                       {
                           Directory dir = (Directory)Actuel;
                           if (dir.Fichiers.Count > 0)
                           {
                               Console.WriteLine();
                               foreach (File file in dir.ls())
                               {
                                   if (file.GetType().ToString() == "FileSystem.Directory")
                                   {
                                       Console.WriteLine("D " + file.Nom);
                                   }
                                   else
                                   {
                                       Console.WriteLine("F " + file.Nom);
                                   }
                               }
                               Console.WriteLine();
                           }
                       }
                       else
                       {
                           Console.WriteLine("Vous n'êtes pas dans un dossier");
                       }
                   }
                   else
                   {
                       goto default;
                   }
                   break;
                   case "cd":
                       if (action.Count == 2)
                       {
                           if (Actuel.isDirectory())
                           {
                               Directory dir = (Directory)Actuel;
                               Actuel = dir.cd(action[1]);
                           }
                           else
                           {
                               Console.WriteLine("Vous êtes dans un fichier");
                           }
                       }
                       else
                       {
                           goto default;
                       }
                   break;
                   case "file":
                       if (action.Count == 1)
                       {
                           if (Actuel.isFile() == true)
                           {
                               Console.WriteLine("C'est un fichier");
                           }
                           else
                           {
                               Console.WriteLine("Ce n'est pas un fichier");
                           }
                       }
                       else
                       {
                           goto default;
                       }
                        
                   break;
                   case "rename":
                   if (action.Count == 3)
                   {
                       if (Actuel.isDirectory())
                       {
                           Directory dir = (Directory)Actuel;
                           dir.renameTo(action[1], action[2]);
                           Actuel = dir;
                       }
                   }
                   else
                   {
                       goto default;
                   }                  
                   break;
                   case "chmod":
                       if (action.Count == 2)
                       {
                           int permission;
                       if (Int32.TryParse(action[1], out permission))
                       {
                           permission = Int32.Parse(action[1]);
                           Actuel.chmod(permission);
                       }
                       else
                       {
                           Console.WriteLine("Permission impossible");
                       }
                       }
                       else
                       {
                           goto default;
                       }
                       
                   break;
                   case "directory":
                   if (action.Count == 1)
                   {
                       if (Actuel.isDirectory() == true)
                       {
                           Console.WriteLine("C'est un répertoire");
                       }
                       else
                       {
                           Console.WriteLine("Ce n'est pas un répertoire");
                       }
                   }
                   else
                   {
                       goto default;
                   }
                   break;
                   case "delete":
                   if (action.Count == 2)
                   {
                       if (Actuel.isDirectory())
                       {
                           Directory dir = (Directory)Actuel;
                           dir.delete(action[1]);
                           Actuel = dir;
                       }
                   }
                   else
                   {
                       goto default;
                   }
                        
                   break;
                   case "root":
                   if (action.Count == 1)
                   {
                       Console.WriteLine(Actuel.getRoot().Nom);
                   }
                   else
                   {
                       goto default;
                   }                   
                   break;
                   case "parent":
                   if (action.Count == 1)
                   {
                       if (Actuel.getParent() != Actuel)
                       {
                           Actuel = (Directory)Actuel.getParent();
                       }
                       
                   }
                   else
                   {
                       goto default;
                   }
                   break;
                   case "exit":
                   if (action.Count == 1)
                   {
                       System.Environment.Exit(-1);
                   }
                   else
                   {
                       goto default;
                   } 
                   break;
                   case "":
                   break;
                   default:
                   Console.WriteLine("Commande inexistante, incomplète ou argument non valide");
                   break;
               }
               commande(Actuel);
            
        }

        public static void runOrNot(List<string> run, Directory Actuel)
        {
            if (run.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Commande érroné ou incomplète");
                Console.ResetColor();
                commande(Actuel);
            }
        }
    }
}
