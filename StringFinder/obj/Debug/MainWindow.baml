   M S B A M L   `   `   `  ����G  CStringFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:StringFinderStringFinder  5   	       StringFinder.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:StringFinder     5   	     � Title$  StringFinder��5   	   $	��650��6   $	��540��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ TextBoxStringInput��5
      $
��Left=�6.   $��22��6I   $��
129,58,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��126��6�   $��13.333(�6�   �� 5   
   -   5         ��Name$ LabelStringInput��5      $��Input Search String:��6*   $��30��6I   $
��Left=�6V   $��	10,50,0,0q�6q   $	��Top=�6�   �� 5   
   -   5         ��Name$ ListBoxWordDocs��5      $
��Left=�6+   $	��100��6F   $��
10,142,0,0q�6S   $	��Top=�6g   $	��497��6    � ContextMenu 5      �� 5      .@�5      m� -   5        $��Add File��5      6G   m� 5      -   5        $��Remove File��5      6L   5      ��5      �� 5      .R�5      � $	��0,2q�6    � ColumnDefinitions 5      �� 5      $��* �6/   .+�5      �� ��6$   �� *
FilePath+��6>   �� *	FileFound+5      5      5      �� 5   
   -   5        $ ListBoxPDFDocs��5      $
��Left=�6*   $	��220��6E   $��
10,296,0,0q�6R   $	��Top=�6f   $	��497��6~    5      �� 5       .@�5!      m� -   5        $��Add File��5!      6F   m� 5"      -   5        $��Remove File��5"      6K   m� 5#      -	   5        $��	Open File��5#      6K   5$      ��5&      �� 5'      .R�5(      � $	��0,2q�6    5)      �� 5*      $��* �6/   .+�5,      �� ��6$   �� *
FilePath+��6>   �� *	FileFound+5-      5.      50      �� 51   
   -
   5        $ LabelWordDocs��51      $2��,Right Click - Add/Remove Word Docs to Search��6'   $
��Left=�6^   $��	10,98,0,0q�6y   $	��Top=�6�   $	��280��6�   �� 52   
   -   5        $ LabelPDFDocs_Copy��52      $1��+Right Click - Add/Remove PDF Docs to Search��6+   $
��Left=�6a   $��
10,265,0,0q�6|   $	��Top=�6�   $	��280��6�   �� 53   
   -   5         ��Name$ ButtonSearch��53      $��Search��6'   $
��Left=�68   $��
10,558,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 54   
   -   5        $ ButtonClear��54      $��Clear��6&   $
��Left=�66   $��432,558,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   57      58      