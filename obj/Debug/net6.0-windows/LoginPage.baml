   M S B A M L   `   `   `  ����N  JOneTimePadAlgorithm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OneTimePadAlgorithmOneTimePadAlgorithm  5      #    OneTimePadAlgorithm.LoginPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:OneTimePadAlgorithm     5        N� Title$  	LoginPage��5	       N� 
Background
 ��� �.��5      �� ���#2e3137 �� CornerRadius$ 50��6#   $	��450��65   $	��500��6A   ._�5   
   �� $��20q�6   .+�5      �� $��One Time Pad��6   
����� �$��
Montserrat)�6>   $��40(�6V   $��Center=�6d   $��Medium"�5      �� 5      $��Username��6   
�������$��18(�5      $��
Montserrat)�5      $��0,10,0,0q�5      �� 5      -   5         ��Name$ txtUsername��5      $��19(�5      $��
Montserrat)�5      $��40��5      $��0,10,0,0q�5      
�������$��5,8,0,0q�5      �� 5      -   5         ��Name$ errorUsername��5      $�� ��6   
����p��$��12(�5      $��
Montserrat)�5      $��0,2,0,0q�5      �� 5       $��Password��6   
�������$��18(�5"      $��
Montserrat)�5#      $��0,30,0,0q�5$      G� 5%      -   5         G�Name$ txtPassword��5%      $��19(�5&      $��
Montserrat)�5'      $��40��5(       G� PasswordChar$ *��6"   $��0,10,0,0q�5)      
�������$��5,10,0,0q�5*      �� 5+      -   5        $ errorPassword��5+      $�� ��6   
����p��$��12(�5-      $��
Montserrat)�5.      $��0,2,0,0q�5/      �� 50      -   5         ��Name$ btnLogin��50      $��
40,40,40,5q�51      $��50��52      $	��200��53      $��LOG IN��54      $��30(�55      $��Medium"�56      
�������
����� � � Cursor$
 Hand��59      5:      �� 5<      $��Don't have an account?��6   
�������$��18(�5>       $��Medium"�5?       $��
Montserrat)�5@       	 �� TextAlignment$	 Center=�5A      �� 5B      -   5        $ btnSign��5B      $��0,0,0,0q�5C      $��30��5D      $	��100��5E      $��Sign up��5F      $��19(�5G      $��Medium"�5H      
����������#2e3137$
 Hand��5K      ���#2e31375M      5N      5O      5P      