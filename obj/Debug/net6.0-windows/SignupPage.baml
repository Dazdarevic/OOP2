   M S B A M L   `   `   `  ����N  JOneTimePadAlgorithm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OneTimePadAlgorithmOneTimePadAlgorithm  5      $    OneTimePadAlgorithm.SignupPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:OneTimePadAlgorithm     5        N� Title$  
SignupPage��5	       N� 
Background
 ��� �.��5      �� ���#2e3137 �� CornerRadius$ 50��6#   $	��450��65   $	��550��6A   ._�5   
   �� $��20q�6   .+�5      �� $��One Time Pad��6   
����� �$��
Montserrat)�6>   $��40(�6V   $��Center=�6d   $��Medium"�5      �� 5      $��Username��6   
�������$��18(�5      $��
Montserrat)�5      $��0,10,0,0q�5      �� 5      -   5         ��Name$ txtUsername��5      $��19(�5      $��
Montserrat)�5      $��40��5      $��0,10,0,0q�5      
�������$��5,8,0,0q�5      �� 5      -   5         ��Name$ errorUsername��5      $�� ��6   
����p��$��12(�5      $��
Montserrat)�5      $��0,2,0,0q�5       �� 5!      $��Password��6   
�������$��18(�5#      $��
Montserrat)�5$      $��0,10,0,0q�5%      G� 5&      -   5         G�Name$ txtPassword��5&      $��19(�5'      $��
Montserrat)�5(      $��40��5)       G� PasswordChar$ *��6"   $��0,10,0,0q�5*      
�������$��5,10,0,0q�5+      �� 5,      -   5        $ errorPassword��5,      $�� ��6   
����p��$��12(�5.      $��
Montserrat)�5/      $��0,2,0,0q�50      �� 51      .+�52      �� $
��Role��6   
�������$��18(�54      $��
Montserrat)�55      $��2,10,0,0q�56      	� 57      -   5         	�Name$ 	btnRadio1��5<      $��student��57      
�������$��16(�59      $��5,8,0,0q�5:      $��5,-5,0,0q�5;       d� 	IsChecked$
 TrueY�5<   1   	� 5=      -   5        $ 	btnRadio2��5B      $��admin��5=      
�������$��16(�5?      $��5,8,0,0q�5@      $��5,-5,0,0q�5A      5B      5C      �� 5D      -   5        	 ��Name$	 	btnSingup��5D      $��
20,20,20,5q�5E      $��50��5F      $	��250��5G      $��Create account��5H      $��30(�5I      $��Medium"�5J      
�������
����� �
 � Cursor$

 Hand��5M      5N      �� 5P      $��Already have an account?��6   
�������$��18(�5R       $��Medium"�5S       $��
Montserrat)�5T        �� TextAlignment$ Center=�5U      �� 5V      -   5        $	 btnLogin��5V      $��0,0,0,0q�5W      $��30��5X      $	��100��5Y      $��Login��5Z      $��19(�5[      $��Medium"�5\      
����������#2e3137$

 Hand��5_      ���#2e31375a      5b      5c      5d      