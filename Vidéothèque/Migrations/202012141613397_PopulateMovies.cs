namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Joker'
                            ,'Todd Phillips'
                            ,'Joaquin Phoenix, Robert De Niro, Zazzie Beetz, Brett Cullen, Alec Baldwin, ...'
                            ,'In the 1980s, in Gotham City, Arthur Fleck, a failed stand-up comedian is assaulted while on the streets of the city disguised as a clown. Despised by all and scorned, he gradually descends into madness to become the Joker, a dangerous psychotic killer.'
                            ,6
                            ,'14/12/2020'
                            ,'02/10/2019'
                            ,100
                            ,'coverJoker.jpg'
                            ,'posterJoker.jpg'
                            ,2
                            ,02
                            ,17
                            ,0);                
                
                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES
                            ('Gone Girl'
                            ,'David Fincher'
                            ,'Ben Affleck, Rosamund Pike, Carrie Coon, Niels Patrick Harris, ...'
                            ,'A prominent couple in New York where they live, Amy and Nick Dune have to move to Missouri when Nick loses his job. As they prepare to celebrate their fifth wedding anniversary, Amy disappears. Noticing traces of a struggle in the house, Nick immediately calls the police. The leads followed and the clues collected direct the suspicions of the media and the neighborhood towards Nick.'
                            ,9
                            ,'14/12/2020'
                            ,'08/10/2014'
                            ,100
                            ,'coverGoneGirl.jpg'
                            ,'posterGoneGirl.jpg'
                            ,2
                            ,29
                            ,12
                            ,0);
            
                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Shutter Island'
                            ,'Martin Scorsese'
                            ,'Leonardo DiCaprio, Mark Ruffalo, Ben Kingsley, Michelle Williams, Emily Mortimer, ...'
                            ,'In 1954, a murderer, extremely dangerous, placed in psychiatric detention center disappeared on the island of Shutter Island. Two officers of the Federal Marshals Corps, Teddy Daniels and Chuck Aule, are dispatched to investigate. Very quickly, Teddy Daniels realizes that the staff of the establishment is hiding something. Only clue he has: a piece of paper on which is scrawled a series of numbers interspersed with letters.'
                            ,9
                            ,'14/12/2020'
                            ,'24/02/2010'
                            ,100
                            ,'coverShutterIsland.jpg'
                            ,'posterShutterIsland.jpg'
                            ,2
                            ,19
                            ,10
                            ,0);

                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Very Bad Trip'
                            ,'Todd Phillips'
                            ,'Bradley Cooper, Zach Galifianakis, Ed Helms, Ken Jeong, Heather Graham, ...'
                            ,'Three young men search for a missing friend during a super party in Las Vegas. The trio must try to remember all the bad decisions made the day before in order to find their friend and bring him back in time for his planned wedding in Los Angeles.'
                            ,5
                            ,'14/12/2020'
                            ,'24/06/2009'
                            ,100
                            ,'coverVeryBadTrip.jpg'
                            ,'posterVeryBadTrip.jpg'
                            ,1
                            ,48
                            ,9
                            ,0);

                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Interstallar'
                            ,'Christophr Nolan'
                            ,'Matthew McConaughey, Anne Hathaway, Jessica Chastain, Michael Caine, Mackenzie Foy, ...'
                            ,'In the near future, the Earth is less and less welcoming to humanity which is experiencing a serious food crisis. The film chronicles the adventures of a group of explorers who use a recently discovered rift in space-time to push human limits and set off to conquer astronomical distances on an interstellar journey.'
                            ,15
                            ,'14/12/2020'
                            ,'05/11/2014'
                            ,100
                            ,'coverInterstellar.jpg'
                            ,'posterInterstellar.jpg'
                            ,2
                            ,49
                            ,16
                            ,0);

                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Skyfall'
                            ,'Sam Mendes'
                            ,'Daniel Craig, Judi Dench, Javier Bardem, Naomie Harris, Bérénice Marlohe, ...'
                            ,'Left for dead after a mission to Turkey that turned into disaster, British agent James Bond, code name 007, reappears in London when he learns from news reports that an attack has been committed against the M16. This event considerably shakes the authority of Director M.'
                            ,1
                            ,'14/12/2020'
                            ,'26/10/2012'
                            ,100
                            ,'coverSkyfall.jpg'
                            ,'posterSkyfall.jpg'
                            ,2
                            ,24
                            ,14
                            ,0);
                
                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Avengers: Endgame'
                            ,'Joe Russo, Anthony Russo'
                            ,'Chris Evans, Robert Downey Jr, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Jeremy Renner, Josh Brolin, ...'
                            ,'The Titan Thanos, having succeeded in appropriating the six Infinity Stones and bringing them together on the Golden Gauntlet, was able to achieve his goal of pulverizing half the population of the Universe. Five years later, Scott Lang, aka Ant-Man, manages to escape the subatomic dimension where he was trapped. He offers the Avengers a solution to bring back to life all the missing beings, including their allies and teammates: recover the Infinity Stones in the past.'
                            ,1
                            ,'14/12/2020'
                            ,'24/04/2019'
                            ,100
                            ,'coverAvengersEndgame.jpg'
                            ,'posterAvengersEndgame.jpg'
                            ,3
                            ,02
                            ,18
                            ,0);

                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Pulp Fiction'
                            ,'Quentin Tarantino'
                            ,'John Travolta, Uma Thurman, Samuel L. Jackson, Bruce Willis, ...'
                            ,'The bloody and burlesque odyssey of little thugs in the Hollywood jungle through three intertwining stories. In a restaurant, a couple of young robbers, Pumpkin and Yolanda, discuss the risks involved in their activity. Two mobsters, Jules Winnfield and his friend Vincent Vega, who returns from Amsterdam, are tasked with recovering a briefcase with mysterious contents and bringing it back to Marsellus Wallace.'
                            ,6
                            ,'14/12/2020'
                            ,'12/05/1994'
                            ,100
                            ,'coverPulpFiction.jpg'
                            ,'posterPulpFiction.jpg'
                            ,2
                            ,58
                            ,11
                            ,0);

                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Forrest Gump'
                            ,'Robert Zemeckis'
                            ,'Tom Hanks, Robin Wright, Gary Sinise, Sally Field, Mykelti Williamson, ...'
                            ,'Over the course of the various interlocutors who come to sit in turn next to him on a bench, Forrest Gump tells the fabulous story of his life. His life is like a feather that lets itself be carried by the wind, just as Forrest lets himself be carried by the events he goes through in America in the second half of the 20th century.'
                            ,9
                            ,'14/12/2020'
                            ,'05/10/1994'
                            ,100
                            ,'coverForrestGump.png'
                            ,'posterForrestGump.jpg'
                            ,2
                            ,22
                            ,11
                            ,0);

                INSERT INTO [dbo].[Movies]
                            ([Title]
                            ,[Director]
                            ,[Actors]
                            ,[Synopsis]
                            ,[GenreId]
                            ,[DateAdded]
                            ,[ReleaseDate]
                            ,[NumberInStock]
                            ,[ImagePath]
                            ,[ImagePoster]
                            ,[DurationHours]
                            ,[DurationMinutes]
                            ,[Price]
                            ,[NbRent])
                    VALUES 
                            ('Tenet'
                            ,'Christopher Nolan'
                            ,'Robert Pattinson, Elizabeth Debicki, John David Washington, Kenneth Branagh, ...'
                            ,'With only one word - Tenet - and determined to fight to save the world, our protagonist travels through the twilight universe of international espionage. His mission will project him into a dimension that exceeds time. However, this is not a time travel, but a time reversal ...'
                            ,15
                            ,'14/12/2020'
                            ,'26/08/2020'
                            ,100
                            ,'coverTenet.jpg'
                            ,'posterTenet.jpg'
                            ,2
                            ,30
                            ,19
                            ,0);
                GO
            ");

        }
        
        public override void Down()
        {
        }
    }
}
