# bancdoor
a website that communicates with the databases of systems directly and displays the results and allows some level of comparisom and interaction with it.

ideally this is used for test systems that are opaque and in which it can be difficult to verify the results of tests and what is really happening in the database

*note on the name* - the reason this project is called bancdoor is that I was working on a banking system when I conceived of the idea to have a single tool for querying multiple databases through an easy to use web interface

##architecture

###code structure

###configuration files
There are three levels of configuration files in the application.
* web.config - holds the database connectionstrings and the location of the pages configuration file
* pages.xml - holds the details of each page and the queries that are used on that page
* query_xxxxx.xml - hold the details of individual queries

##design
standard design elements

##visualisation
provided by the raphaeljs library

##interactivity

##security
no security is implemented by default on these pages - it is recommended that a level of security is implemented by anyone using this system

