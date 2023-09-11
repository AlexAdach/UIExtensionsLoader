# UIExtensionsLoader
 Crestron Module for loading master UI extension file

 This module is intended to simplify loading and management of UI extensions for a large project. The idea is to have one master UI extensions file for a project. You create a separate "panel" for each room varation. The Crestron program loads the entire configuration file, finds the correct varation you define and loads that to the Roomkit.

 Load config command:

 - Loads the file as defined by filepath.
 - Searches the file for the panel ID you define in TargetPanelID.
 - Retrieves a list of all the loaded UI extensions on the roomkit.
 - Finds all the extensions with the "Control Panel Prefix" and deletes them. This is to reinitialize the extensions without accidently deleting client loaded UI extensions. So the panel file you want to load should have this prefix ie Prefix = "Control_". Target Panel Id = "Control_Boardroom".
 - Pushes the correct panel file.

This is all done with Rest commands so that needs to be enabled on the codec. 
