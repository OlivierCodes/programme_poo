using System;
using System.Collections.Generic;
using System.Linq;

namespace programme_poo
{

	class Enfant : Etudiant
	{
		string classEcole;
		Dictionary<string, float> notes;
		public Enfant(string nom, int age, string classEcole) : base(nom, age, null)
		{
			this.classEcole = classEcole;
		}

		public override void Afficher()
		{
			AfficherNomEtAge();
            Console.WriteLine("   Enfant en classe de " + classEcole);
			AfficherProfesseurPrincipal();
        }
	}


	class Etudiant : Personne
	{
		Personne professeurPrincipal;
		string infoEtudes;
		public Etudiant(string nom, int age, string infoEtudes, Personne professeurPrincipal = null) : base(nom, age, "Etudiant")
		{
			this.infoEtudes = infoEtudes;
			this.professeurPrincipal =professeurPrincipal;	
			
		}

		public override void Afficher()
		{
			AfficherNomEtAge();
			Console.WriteLine("		Etudiant en " + infoEtudes);
			AfficherProfesseurPrincipal();

        }


		protected void AfficherProfesseurPrincipal()
		{
			if (professeurPrincipal != null)
			{
				Console.WriteLine("		Professeur principal: ");
				professeurPrincipal.Afficher();
			}
		}
	}

	class Personne
	{
		static int nombreDePesronne = 0;
		public string nom;
		public int age;
		public string emploi;
		int numeroPersonne;

		public Personne(string nom, int age, string emploi=null)
		{
			this.nom = nom;
			this.age = age;
			this.emploi = emploi;
			nombreDePesronne++;
			this.numeroPersonne = nombreDePesronne;
		}

		public virtual void Afficher()
		{
			AfficherNomEtAge();
			if(emploi != null) 
			{
				Console.WriteLine("		EMPLOI: " + emploi);
			}
			else
			{
				Console.WriteLine("		Aucun emploi spécifié");
			}
        }
  

		protected void AfficherNomEtAge()
		{
			Console.WriteLine("PERSONNE N°" + numeroPersonne);
			Console.WriteLine("		NOM: " + nom);
			Console.WriteLine("		AGE: " + age);
		}
	}


	internal class Program
	{
		static void Main(string[] args)
		{
			//var noms = new List<string> {"Paul", "David", "Jacques", "Juliette" };
			//var age = new List<int> { 30, 35, 20, 8};


			var personnes = new List<Personne> {
				new Personne("Paul", 25, "Developpeur"),
				new Personne("Jacques", 30, "Comptable"),
				new Personne("Isak", 27),
				new Personne("Olivier", 30, "Professeur")
			};

			//personnes = personnes.OrderBy(p => p.nom).ToList();

			var Etudiants = new List<Etudiant> {

				new Etudiant("Jean", 22, "Génie Logiciel"),
				new Etudiant("Alex", 20, "Maintenance et Réseaux Informatique", personnes[3])
			
			};

			var Enfants = new List<Enfant>
			{
				new Enfant("Sophie", 7, "CP")
			};

			foreach (Personne personne in personnes)
			{
				personne.Afficher();
			}

            foreach (var etudiant in Etudiants)
            {
				etudiant.Afficher();
            }

			foreach (var enfant in Enfants) { enfant.Afficher(); }
        }
	}
}
