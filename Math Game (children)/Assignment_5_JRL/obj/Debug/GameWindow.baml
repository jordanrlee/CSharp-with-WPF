   M S B A M L   `   `   `  ????K  GAssignment_5_JRL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Assignment_5_JRLAssignment_5_JRL  5   	   !    Assignment_5_JRL.GameWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Assignment_5_JRL     5   	     ? Title$  
GameWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? $??	320,0,0,0q?6    ? RowDefinitions 5
   
   ?? 5      $	??46* ?6   ?? 5      $
??171* ?6   ??5   
   ?? 5       ?? ImageSource$! /Images/tmnt_GameWindow.jpg??6   .+?5   
   ?? -   5         ??Name$ lblQuestionGameWindow??5      $?? ??6/   $
??Left=?6;   $??
-304,8,0,0q?6V   $	??Top=?6j    J? RenderTransformOrigin$ 0.5,0.5&?6?   $	??121??6?   $??42??6?   $??18(?6?   $
??Bold"?6?   $??1??6?   z?5      V? 5      .~?5      ?? ?? 5      ?? 5       ?? Angle$ -0.284Q?6&   T? 5      5      5      ?? 5   
   -   5         ??Name$ txtBoxGameWindow??5      $
??Left=?6,   $??-133,11,0,0q?6G    ?? TextWrapping$
 Wrap=?6\   $	??Top=?6p   $	??120??6?   $??41??6?   $??18(?6?   $
??Bold"?6?   $?? ??6?   $??1??6?   6?   ?? 5   
   -   5         ??Name$ 
buttonQuit??5      $
??Quit??6%   $
??Left=?64   $??-303,106,0,0q?6O   $	??Top=?6e   ???	#FFEC4134$	??120??6?   $??54??6?   $??18(?6?   $
??Bold"?6?   $??1??6?   ?? 5   
   -   5        $ buttonSubmit??5      $??Submit??6'   $
??Left=?68   $??-133,106,0,0q?6S   $	??Top=?6i   $	??120??6?   $??54??6?   ???	#FF8CC63E$ 0.752,0.503&?6?   $??18(?6?   $
??Bold"?6?   $??1??6  ?? 5   
   -   5        $ lblTime??5      $
??Time??6!   $
??Left=?60   $??-303,27,0,0q?6K   $	??Top=?6`   $??18(?6x   $
??Bold"?6?   ?? 5   
   -   5        $ lblRound??5      $??Round??6"   $
??Left=?62   $??-303,53,0,0q?6M   $	??Top=?6b   $??18(?6z   $
??Bold"?6?   ?? 5    
   -   5        $ 
lblSeconds??5       $?? ??6$   $
??Left=?60   $??-243,27,0,0q?6K   $	??Top=?6`   $??18(?6x   $
??Bold"?6?   ?? 5!   
   -   5        $ lblAnswerFeedback??5!      $?? ??6+   $
??Left=?67   $??-133,57,0,0q?6R   $??1??6g   $	??Top=?6t   $??38??6?   $	??120??6?   $??18(?6?   $
??Bold"?6?   5#      5$      