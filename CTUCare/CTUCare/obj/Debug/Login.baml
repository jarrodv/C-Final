   M S B A M L   `   `   `  ����B  >CTUCare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CTUCareCTUCare  5   	       CTUCare.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CTUCare     5   	     � Title$  Login��5   	   $	��300��6   $	��300��6$    � Icon$ images/picture5.png��5	   	   $��3q�6$   ���	#FF3699F1 � 
ResizeMode$ CanMinimize=�5
   	   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ txtUserName��5      $��23��6'   $��39,95,39.6,0q�63    �� TextWrapping$
 Wrap=�6I   $	��Top=�6]   ���	#FF3699F1$	��1.5q�6�   �� 5   
   -   5         ��Name$ label��5      $��Username��6   $
��Left=�62   $��	39,64,0,0q�6M   $	��Top=�6`   $��83��6x   �� 5   
   -   5        $ 
label_Copy��5      $��Password��6$   $
��Left=�67   $��
39,124,0,0q�6R   $	��Top=�6f   $��83��6~   G� 5   
   -   5         G�Name$ txtPassword��5      $��39,155,40,0q�6+   $	��Top=�6@    J� RenderTransformOrigin$ 0.5,0.5&�6X   $��23��6x   ���	#FF3699F1$	��1.5q�6�   �� 5   
   -   5        	 ��Name$	 btnLogin��5      $��Login��6#   $��39,198,166,0q�63   $	��Top=�6I   ���	#FF3699F1$	��1.5q�6y   
�������$��25��6�   6�   �� 5   
   -   5        $	 
btnAddUser��5      $��Add User��6%   $��165,198,40,0q�68   $	��Top=�6N   ���	#FF3699F1$	��1.5q�6~   
�������$��25��6�   6�   �� 5   
   $��79��6   $��202,10,34,0q�6    $	��Top=�65   ��5      �� 5      
 �� ImageSource$
 Images/Picture5.png��6    j� Stretch$ Uniform=�6?   5      5      5      