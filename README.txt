Conferenceware README
=====================

Conferenceware is a project for running a conference. It is designed to run the ACM Reflections|Projections project. It runs on IIS and Microsoft SQL Server

1) Installation
---------------

  The installer will verify that you are running an NT based Windows system and that IIS 4+ is there. This is very much not sufficient. This actually required IIS 7 not in compatibility mode and the following features added to the role: Static files, ASP.NET, and IIS 6 Metabase Compatibility
  It expects SQL Server to be installed and with a database called Conferenceware available with the installing person able to create the contents of the database.