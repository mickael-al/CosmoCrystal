# Cosmo Crystal

## Spécifications :
* Type : RPG tour par tour
* POV : Third Person (Pikmin 3)
* Moteur : 3D
* Style graphique : Stylized shading

## Gameplay
* #### Combat :
	* ##### types :
		![image](diagramme_faible.svg)
	* ##### attaques :
		![image](diagramme_attaque.svg)
		* attaques de feu :
			* attaque simple basique (--flammèche--) _lv 1_ :
				* _petite boule de feu -> dégats unique_
			* attaque spé basique (--orbe enflammé--) _lv 5_ :
				* _sphère de feu -> dégats de zone_
			* attaque simple avancé (--crocs de feu--) _lv 10_ :
				* _morsure de feu -> dégats unique_
			* attaque spé avancé (--déflagration--) _lv 15_ :
				* _lance flamme -> dégats de zone_
			* QTE :
				* spam pour augmenter le curseur (doit rester dans la bonne partie de la jauge)
				* spam pour comprimé la boule de feu
		* attaques d'eau :
			* attaque simple basique (--hydroslash--) _lv 1_ :
				* _slash d'eau -> dégats unique_
			* attaque spé basique (--aquapulse--) _lv 5_ :
				* _jet laminaire d'eau -> dégats unique_
			* attaque simple avancé (--noyade--) _lv 10_ :
				* _une bulle d'eau qui englode les ennemis -> dégats de zone_
			* attaque spé avancé (--hydroblast--) _lv 15_ :
				* _un jet d'eau puissant -> dégats unique_
			* QTE :
				* style simon
				* parcours graph
				* suivre point avec un mouvement aléatoire
		* attaque de plante :
			* attaque simple basique (--photo synthèse--) _lv 1_ :
				* _une fleur que régen avec son pollen -> soin_
			* attaque spé basique (--fouet liane--) _lv 5_ :
				* _un fouet de liane -> dégats unique_
			* attaque simple avancé (--éruption vénéneuse--) _lv 10_ :
				* _des racines sortant du sol -> dégats de zone_
			* attaque spé avancé (--tournesol--) _lv 15_ :
				* _une fleur qui capte le soleil pour envoyer un rayon -> dégats unique_
			* QTE :
				* style osu catch
				* style osu taiko
				* dégats unique
		* attaque de ténèbre :
			* attaque simple basique (--malédiction--) _lv 1_ :
				* _une poupé maudite qui fait des dégats de status sur plusieurs tours -> dégats unique_
                	* attaque spé basique (--fauchage--) _lv 5_ :
                		* _une faucheuse qui fait des dégat ciblé à un ennemi -> dégats de zone_
                	* attaque simple avancé (--épines ténébreuses--) _lv 10_ :
                		* _un mur d'épines qui partent graduellement en direction des ennemis aléatoirement -> dégats de zone_
                	* attaque spé avancé (--distortion--) _lv 15_ :
                		* _une singularité qui créé une distortion infligeant des dégats conséquant à l'ensemble des ennemis -> dégats de zone_
			* QTE :
				* suite de séquences de symboles à entrer dans le bon ordre
		* attaque de combat :
			* attaque simple basique (--éclat poing--) _lv 1_ :
				* _une boule de roche apparait et le joueur frappe dedans pour l'envoyer dans l'ennemi -> dégat unique_
			* attaque spé basique (--choc télurique--) _lv 5_ :
				* _une onde de choc qui fait des dégats à tous les ennemis -> dégats de zone_
			* attaque simple avancé (--frappe éclair--) _lv 10_ :
				* _le joueur se déplace rapidement sur l'ennemi pour le frapper -> dégats unique_
			* attaque spé avancé (--ultra poing--) _lv 15_ :
				* _le joueur concentre sont pouvoir pour frapper à distance l'ennemi -> dégats unique_
			* QTE :
				* suite de touche à faire rapidement
		* attaque de psy :
			* attaque simple basique (--onde psy--) _lv 1_ :
				* _le joueur envoie un rayon psychique sur un ennemi -> dégats unique_
			* attaque spé simple (--télékinésie--) _lv 5_ :
				* _le joueur soulève l'ennemi dans les air et le fait tomber -> dégats unique_
			* attaque simple avancé (--dépression gravitationnelle--) _lv 10_ :
				* _l'ennemi reçoit des dégats d'écrasement sur plusieurs tours -> dégats unique_
			* attaque spé avancé (--choc magique--) _ lv 15 :
				* _créé une zone de controle mental qui baisse la vitesse des ennemis et leur fait des dégats -> dégats de zone_
			* QTE :
				* esquiver des projectile pendant un certains temps (undertale)
	* ##### monstres :
		* idées :
			slime, squelettes, chauve souris, feu follets, golem, humains, arbres vivant, troll, champi, goules, méduse volante psy, poulpe, crabe, gobelins, mécanoïds, shadow monsters, blob, coffre vivants, vers de sable, ombrage (harry potter), phenix
	* ##### level design :
		* biomes : 
			--généralités-- : Les biomes sont de différents types et contiennent des créatures de leurs type _(forêt contient des créatures de type plante)_. Certains biomes peuvent être de deux types différents est servir d'habitation à des créatures multitypes plus puissantes.
		* donjons : 
			* --généralités-- : Les donjons sont rempli de monstres de tout les types différents. Ceux ci contiennent des énigmes dont la résolution permet de progresser dans les différentes pièces et étages.
		* abilitées :
			* --morsure-- : une abilité permettant de détruire un éléments faibles (feuillage, racien, etc...) / _type normal_
			* --boule de feu dirigé-- : une boule de flamme permettant d'actionner un reseau d'éléments (allumer un reseau de torche, etc...) / _type feu_
			* --pikmin troups-- : une petite araignée controllable et passe partout. / type psy
			* --grappin liane-- : un grappin permettant de traverser des obstacles. / type plante
			* --respi-bulle-- : une bulle d'air permettant de respirer sous l'eau indéfiniment. / type eau
			* --dimentional extention-- : une capacité permettant de de rentrer en phase avec la quatrième dimension. / type ténèbre
		* énigmes :
			* --salle sombre-- : le joueur peut acquérir des capacités liées au type exemple feu flammèche -> Activer les torches
			* --puzzle de torches-- : Activer plusieurs torche lui permet d'ouvrir une portes/faire apparaître un coffre
			* --fossé franchissable avec grappin-- : le joueur peut passer de l'autre côté d'un fossé via un grappin.
			* --Interupteur(Switch)-- : le joueur peut activer des interupteur pour ouvrir des portes.
			* --blocks/physique-- : le joueur peut déplacer des blocs de pierre pour activer des mécanismes.
			* --Control Mental-- : le Joueur peut prendre le contrôle de petites araignées qu'il peut contrôler dans des petites zones. 
	* ##### items et marchands :
		* items :
			* --items de buff-- : le joueur pourra acheter des objets spéciaux à des marchands, il pourra en porter un au maximum et  il lui donnerons un buff au détriment d'un débuff. 
## Histoire
* #### Contexte :
	L'intrigue de l'histoire ce déroule dans un monde séparé en quatre continents, celui de la neige, de la forêt, du feu et celui de la mer. Divers espèces de monstres y vivent, chacune ayant des attribues spécifiques à leurs habitats. Un type de monstres  plus exotique existe aussi dans ce monde, il s'agit des monstres de cristaux, le joueur est lui même un monstre de ce type. Ces monstres n'apparaissent que très rarement (tout les quatre millénaire environ) et sortent du sol tous en même temps durant une période que l'on appelle --l'éclosion--. Du fait de la rareté de ces monstres et de leurs propriétés métaboliques, ceux-ci sont énormément chassé par --les humains-- durant cette phase où ils sont les plus simples à tuer, le temps le rendant rapidement beaucoup trop puissant. Autrefois, ces créatures étaient protégé par un immense champs de protection infranchissable qui rendais leur lieu d'éclosion inattaquable jusqu'à ce qu'il atteigne l'age adulte et devienne de majestueuses et très puissante créature. Malheureusement, il y a de ça 20 000 ans, un groupe d'humains parvient à détruire le générateur et à canalisé toute sa puissance dans un artéfact appelé 'la relique du chaos', nommé ainsi par les humain du fait de la puissance quelle contient et de la quantité d'énérgie libéré lors de la destruction du champ de force, créant une onde de choc de 10 sur l'échelle de Richter sur l'ensemble des quatre continents et prenant d’innombrable vies humaines. Cet artefact est aujourd'hui enfermé dans les tréfonds du plus grand temple humain, là ou personne n’oserait pénétrer.
* #### Objectif :
	Le héros étant un monstre de cristal venant de naitre, il doit dans un premier temps prendre en considération le monde qui l'entour, il devra donc interagir avec certains élément de l'environnement et avec les PNJs plus ou moins amicaux qui peuple le monde (La traitrise et la manipulation par les PNJs sera beaucoup mise en avant pour faire comprendre au joueur l'envers du décors, il devra donc faire attention à qui il peut faire confiance). Au fil de son aventure qui consistera en grande partie à récupérer des informations et résoudre des énigmes dans les quatre donjons élémentaires situés chacun dans un contient. Après avoir pris connaissance de l'histoire du champs de force et de la relique. Le joueur apprendra que celle ci est enfermé dans le grand temple humain depuis 20 000 ans. Le grand temple humain fera office de donjon final et pourra être accessible au joueur uniquement après qu'il ai terminé les quatre donjons élémentaires, libérant alors assez d’énergie dans le monde pour activer la porte du temple. Arrive alors la partie final du jeu où le héros se retrouvera confronté à de multiples pièges et créatures plus puissants les uns que les autres pour enfin atteindre la relique et rétablir le champ de force.
* #### Joueur :
	Le joueur démarre la partie sur l'éclosion de son avatar en brisant le cristal-œuf dans lequel il a été incubé durant des millénaires. Il prend la forme d'une petite araignée ornée de cristaux répartie partout sur ça carapace.
* #### Caractéristiques des créatures :
	* ##### les créatures de cristal :
		Ces créatures extrêmement rare ne naissent que tous les 4000 ans et sont ornées de cristaux très rare et puissant beaucoup convoitées par les humains. Il possède également un noyaux d’énergie très puissant qu'ils peuvent utiliser pour contrôler momentanément une créature carboné _(cf : gameplay ally)_ ou encore pour s'approprier les compétences élémentaires des environnement qu'il traverse _(cf : gameplay compétences élémentaires)_.
	* ##### les créatures carbonés :
		Ces créatures sont les plus courante dans le monde et possèdent des caractéristique propre à leurs environnement _(Eau, Feu, Plante, Psy, Ténèbre, Combat)_. Ils peuvent être relativement hostile avec le joueur et peuvent lui poser problème suivant son type prédominant.
* #### PNJs principaux :
	* ##### Échidna :
		Cette créature moitié femme moitié serpent est un personnage rencontré par le jouer au début de la partie. Celui-ci la voit en difficulté face à un groupe de chasseur humains. Le joueur et alors accompagné de son acolyte Lanthel _(personnage tuto, créature de cristal né au même moment)_ et observe la scène de loin. La créature humanoïde semblant montrer des signes de faiblesse et implorant de l'aide, Lanthel se précipite alors pour s’interposer entre les humains et la créature. C'est alors qu'il reçoit un coup mortel de la part du la femme serpent qui fait alors fuir les humains. Le héros resté à l'écart prend peur et se sauve _(cette cinématique permet de mettre fin au tutoriel de base et permet de montrer au joueur l'envers du décor)_.
		
		* Information sur le personnage :
			_Échidna est une ancienne esclave des humains qui cherche à se venger en exterminant les humains. C'est pour cela qu'elle se met en quête de la relique du chaos après avoir appris son existence par une erreur du joueur._  
	* ##### Argo :
		Argo est un chasseur humain dont l'objectif est de traquer Échidna du fait de la prime sur ça tête, c'est un personnage grossier qui ne porte pas réellement d'intérêts au joueur.
	* ##### Lanthel :
		Tout comme le joueur, Lanthel est une créature de cristal, il éclos au même moment que le joueur non loin de lui. Il servira de tutoriel basique au joueur avant de se faire violemment tué par Échidna peut de temps après.
## Developpement
* #### design pattern :
	[les design patterns du jeu-vidéo](https://slides.com/red-red/les-design-patterns-du-jeu-video/fullscreen)


