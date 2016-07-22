# Band Tracker
### By Stewart Cole, 7/22/2016 ###
<br>

### Setup

* Assuming you are running on windows and you have mono and nancy installed. (http://www.mono-project.com/docs/getting-started/install/windows/)
* Clone the repository at
(https://github.com/CrucialGier/csharp-week4review-BandTracker.git)
* using the command git clone
* Create empty databases using the .sql files provided by opening them in Microsoft SQL Server Manager Studio and executing the scripts or type the commands :

CREATE DATABASE band_tracker

GO

USE band_tracker

GO

CREATE TABLE bands

(

	id int IDENTITY(1,1),

	name varchar(255),

)

GO

CREATE TABLE venues

(

	id int IDENTITY(1,1),

	name varchar(255)

)

GO

CREATE TABLE venues_bands

(

  id int IDENTITY(1,1),

  id int venue_id,

  id int band_id;

)

GO



* Enter the Project's directory using the console and enter dnu restore and then dnx kestrel

* Visit localhost:5004 in your web browser.


### Specs

* When the user enters a new Venue or Band, that value should by saved to the database for use later.
   * Input: "Frets on Fire";
   * Output: Database Row: Id - 1, Name - Frets on Fire;


* When the user visits the Venues or Bands page it should retrieve and display all applicable instances.
  * Input: User Clicks "View Bands";
  * Output: Page Displayes: "Frets on Fire", "Crimson Typhoon and the Knife Heads";


* It can delete all instances of Venues or Bands.
  * Input: User Clicks "Delete All Bands";
  * Output: Database is Emptied, Page displayes: "You have no bands"


* It can find a specific band or venue based on their id numbers.
  * Input: User clicks a band;
  * Output: Webpage finds and displayes all bands with matching ids;


* It can edit the name of a band or venue.
  * Input: User Clicks "Edit Band" and enters "George";
  * Output: Page Returns updated band "George";


* It can delete specific bands or venues.
  * Input: User Clicks "Delete Band" button;
  * Output: Webpage Removes that band from the list of bands;


* It can find all bands for a specific venue.
  * Input: User Clicks "Shatter Dome";
  * Output: Webpage returns Shatter Dome page with a list of her bands.

### Known Bugs

None at the moment

### Technologies Used

Atom
C#
Html
Nancy
Razor
SQL
Microsoft SQL Server Management Studio

### Copyright

Stewart Cole copyright(c) 7/15/2016
