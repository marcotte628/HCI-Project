

HCI Final Project

How to set up and run:
1. pull the entire project directory 
2. open the HCI Project.sln file in visual studios
3. click the run button within Visual Studio 
4. a browser will open and you will be automatically sent to the landing page of the site


Architecture Description
- App_Start: 
	controls the startup of the application
	sets the landing page of the site when opening it for the first time
	
- Content:
	contains CSS files for using the bootsrrap libraries
	
- Controllers:
	contains C# files that serve as the files that receive API calls from the browser
	
- css:
	contains the CSS files for styling the HTML files
	
- fonts:
	contains references to resources for glyphicons

- images: 
	a folder used to store default images and uploaded images

- js: 
	declaration file for angular module
	- js: 
		JavaScript controllers for handing actions on different views

- Models: 
	- QueryHandler
		C# handlers for making SQL Database calls

- modules:
	resource for using the Bootstrap library 

- Scripts:
	references to resources needed to use jQuery functionality

- Views:
	HTML files of the project
	- Shared: 
		Layout file that is shared across all HTML paritals 
		defines the <head> of the html files
	- AddPatient:
	
	
	- ComparePatient:
		HTML partial that defines the view of the compare page 
	
	- EditPatient:
		HTML partial that defines the view of the edit page 
	
	- PatientInfo:
		HTML partial that defines the view of the patient info page 
	
	- Home: 
		HTML partial that defines the view of the home page 
		
	- Login:
		HTML partial that defines the view of the login page 
		
	- Register: 
		HTML partial that defines the view of the register page 
