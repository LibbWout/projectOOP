   M S B A M L   `   `   `  ����F  BProject_OOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_OOPProject_OOP  5   	       Project_OOP.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_OOP     5   	   -   5          � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�6   .��5	      �� .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��tbxZoek��5   -   $	��565��6   $��5q�6"   6>   �� 5      -   5        $��btnZoek��5   ,   $	��100��6   $��5q�6!   .��6Q   Zoek6W   �� 5      -   5        $��btnStop��5   ,   $	��100��6   $��5q�6!   .��6Q   Stop met zoeken6b   5      �� 5   
   $��Personen��6   .��5      �� -   5         ��Name$ LstvPersonen��5       �� SelectionMode$ Single=�6-   $	��100��6E   5      5      �� 5   
   $��	Bedrijven��6   .��5      �� -   5        $ LstvBedrijven��5      $	��100��6/   $ Single=�6<   5      5      �� 5   
   -   5        $��lblZoek��5      6!   �� 5   
   -   5        $��grbxVoornaam��5   %   $��Voornaam��6   $y�	Collapsed=�69   .��5       �� -	   5        $��tbxVoornaam��5       6-   5!      �� 5"   
   -
   5        $��grbxAchternaam��5"   '   $��
Achternaam��6   $y�	Collapsed=�6=   .��5#      �� -   5        $��tbxAchternaam��5#      6.   5$      �� 5%   
   -   5        $��grbxBedrijfsnaam��5%   )   $��Bedrijfsnaam��6   $y�	Collapsed=�6A   .��5&      �� -   5        $��tbxBedrijfsnaam��5&      60   5'      �� 5(   
   $��Adres��6   .��5)      �� -   5        $��tbxAdres��5)      ${�False��6&   .��69   6<   5*      �� 5+   
   $��Telefoonnummer��6   .��5,      �� -   5        $��	tbxNummer��5,      ${�False��6'   6;   5-      �� 5.   
   $��Email��6   .��5/      �� -   5        $��tbxMail��5/      ${�False��6%   69   50      �� 51   
   $��Maak je keuze��6   .��52      �� -   5        $��	cmbxKeuze��52      54      55      �� 56   
   $ 
Horizontal=�6   .+�57   
   �� -   5        $��btnToevoegen��57      $��5q�6@   $	��149��6K   .��6W   	Toevoegen6c   �� 58      -   5        $��btnVeranderPersoon��58      $��5q�6P   $	��149��6[   .��6g   Verander Persoon6z   �� 59      -   5        $��btnVeranderBedrijf��59      $��5q�6P   $	��149��6[   .��6g   Verander Bedrijf6y   �� 5:      -   5        $��btnVerwijderPersoon��5:      $��5q�6R   $	��149��6]   .��6i   Verwijder Persoon6}   �� 5;      -   5        $��btnVerwijderBedrijf��5;      $��5q�6R   $	��149��6]   .��6i   Verwijder Bedrijf6|   5<      5?      5@      