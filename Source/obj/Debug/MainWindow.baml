   M S B A M L   `   `   `  ����  
FlappyBird    FlappyBird.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        $	��319��5   @   $	��578��6P     � Title$  Flappy Bird��5   	    � Icon$ Images/FlappyBird.ico��6   $	��319��6:   $	��578��6G   .��5      �� -   5         ��Name$ 
GameCanvas��5      |�. 
�������$��0,0,0,0q�6   .+�5
   
   �� -   5         ��Name$ BackGroundImg��5
      
 � Tag$ 
Background��6'   $
��Fill=�68   $	��306��6G   $	��586��6T   $!��Images\Background Image.png��6`   $��-2,0,-4.667,-29.333q�6�    �� Left$ 0��6�   
 �� Top$ 0��6�   �� 5   
   -   5        $ TheBird��5      $ TheBird��6!   $��Images/FlappyBird.png��6/   $��30��6N   $��30��6Y   $
��Fill=�6e    J� RenderTransformOrigin$ 3.043,3.808&�6t   $ 30��6�   $	 145��6�   �� 5   
   -   5         ��Name$ ScoreTxt��5      $	 lbl��6"   $��Score: 0��6,   
���   �$��14(�6R   $��	ExtraBold"�6`   $��0,0,0.333,-28.333q�6x   �� 5   
   -   5        $ 	DownPipe1��5      $��/Images/DownPipe.png��6$   $ pipe1��6B   $��30��6N   $	��136��6Y   $	 169��6f   $	 200��6x   �� 5   
   -   5        $ TopPipe1��5      $��/Images/TopPipe.png��6"   $ pipe1��6?   $	��117��6K   $��25��6X   $	 170��6c   $	 -17��6u   �� 5   
   -   5        $ 	DownPipe2��5      $��Images/DownPipe.png��6$   $ pipe2��6A   $��30��6M   $	��146��6X   $	 316��6e   $	 161��6w   �� 5   
   -	   5        $ TopPipe2��5      $��Images/TopPipe.png��6"   $ pipe2��6>   $	��117��6J   $��25��6W   $	 315��6b   $	 -50��6t   �� 5   
   -
   5        $ 	DownPipe3��5      $��/Images/DownPipe.png��6$   $ pipe3��6B   $��30��6N   $	��146��6Y   $	 453��6f   $	 207��6x   �� 5   
   -   5        $ FloorPng��5      $��Images/BottomGround.png��6"   $ Floor��6D   $	��585��6P   $��30��6\   $
��Fill=�6h   $	 277��6w   $��1,1,1,1q�6�   $ -8��6�   �� 5   
   -   5        $ TopPipe3��5      $��/Images/TopPipe.png��6"   $ pipe3��6?   $	��135��6K   $��25��6X   $	 454��6c   $	 -12��6u   5      5      