Imports Windows.Globalization.DateTimeFormatting
Imports Windows.ApplicationModel.DataTransfer

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage
    ''' <summary>
    ''' Populates the page with content passed during navigation.  Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="navigationParameter">The parameter value passed to
    ''' <see cref="Frame.Navigate"/> when this page was initially requested.
    ''' </param>
    ''' <param name="pageState">A dictionary of state preserved by this page during an earlier
    ''' session.  This will be null the first time a page is visited.</param>
    Protected Overrides Sub LoadState(navigationParameter As Object, pageState As Dictionary(Of String, Object))

    End Sub
    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="Common.SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    Protected Overrides Sub SaveState(pageState As Dictionary(Of String, Object))

    End Sub
    '#Region "Declarations"
    Public TempStr As String
    Public Wickets As Byte
    Public Runs As Integer
    Public Balls As Integer
    Public TempNum As Integer
    Public RemBalls As Integer
    Public Randomizer As New Random
    Public InningNum As Byte
    Public FullCommentary As String
    Public TypeofPitch As Byte
    Public TotalBalls As Integer
    Public ExpectedScore As Integer
    Public TossW As String
    Public TossL As String
    Public Decis As String
    Public BowlingTeam As String
    Public NotBowled As Boolean
    Public FreeHit As Boolean
    Public WktCont As Byte
    Public WktCont2 As Byte
    Public WktIndex As Byte
    Public NewRun As Integer
    Public NewWkt As Integer
    Public NewExt As Integer
    Public LastBall As String
    Public BallResult As String
    Public RunsBeforeOver As Integer
    Public WicketsBeforeOver As Integer
    Public FirstInning As String
    Public Tgt As Integer
    Public Tgt1 As Integer
    Public Tgt2 As Integer
    Public WASPscore As Integer
    Public Rqpo As Double
    Public MatchResult As String
    Public Uncertainty As Long
    Public MatchSummary As String
    Public HistoryCS As String = ""
    Public GamesInHistory As Integer
    Public RequiredRate As Double = 6
    Const HelpText As String = "INTRODUCTION" & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & "Cricket Simulator is designed to have fun with random (or custom) cricket match scenarios with exclusive real-like commentary." & vbNewLine & vbNewLine & "INSTRUCTIONS" & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & "A match is started by selecting two teams, the format of the game and then clicking on 'Flip Coin' for the toss. The winning captain can choose to bowl or to bat depending upon the pitch conditions. Once you click 'Start Match', the score board appears. You can choose from 'Play Random' or play 'Custom' to continue the proceedings. The full commentary is visible in a textbox on right/bottom." & vbNewLine & vbNewLine & "USE OF CRICKET SIMULATOR" & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & "Cricket Simulator can be used to gamble, check luck, record local matches, predict upcoming matches or even to pass the time." & vbNewLine & vbNewLine & "HISTORY" & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & "Cricket Simulator provides the facility to view the history of the matches you witnessed. Click on the 'History' button in the game to view this information. You can also 'Clear history' from the app bar." & vbNewLine & vbNewLine & "COMMENTARY" & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & "Cricket Simulator features two types of commentary - automatic and custom. The automatic commentary is the default and is available in both, random and custom scenarios. The custom commentary can only be used when adding custom deliveries/events to the game. You can copy the whole commentary from the app bar." & vbNewLine & vbNewLine & "ABOUT" & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & "Cricket Simulator 1.0.2.23" & vbNewLine & "Copyright © 2012 ANIco.in" & vbNewLine & "Licensed as freeware" & vbNewLine & vbNewLine & "DISCLAIMER" & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & "All the team logos, team names and their captain names are the sole property of International Cricket Council (and the respective boards) and are protected by trademark and/or other pending or existing intellectual property rights. Emphasis is to be laid on the fact that we don't own ICC, other cricketing boards or any part of them. Cricket Simulator is designed only for entertainment purpose and is completely non-profit."
    Public RoamSet = Windows.Storage.ApplicationData.Current.RoamingSettings
    Public Formatter As DateTimeFormatter = New DateTimeFormatter("longdate")
    Public DatPack As New DataPackage()
    Public BatsmanOutChance As Integer
    Public BowlerStrikeRate As Integer
    Public BowlerOutChance As Integer
    Public WicketChance As Integer
    Public DotChance As Integer
    Public PercentRuns4 As Integer
    Public PercentRuns6 As Integer
    Public PercentRuns3 As Integer
    Public PercentRunsExtra As Integer
    Public PercentRuns2 As Integer
    Public PercentRuns1 As Integer
    Public FourChance As Integer
    Public SixChance As Integer
    Public ThreeChance As Integer
    Public DoubleChance As Integer
    Public ExtraChance As Integer
    Public SingleChance As Integer
    Public WideChanceFrom As Integer
    Public WideChanceTo As Integer
    Public NoBallChanceFrom As Integer
    Public NoBallChanceTo As Integer
    Public ByeChanceFrom As Integer
    'Public ByeChanceTo As Integer
    Public Wide4ChanceFrom As Integer
    Public Wide4ChanceTo As Integer
    Public FiveChanceFrom As Integer
    'Public FiveChanceTo As Integer
    Public DeadBallChanceFrom As Integer
    Public DeadBallChanceTo As Integer
    Public AppealChanceFrom As Integer
    Public AppealChanceTo As Integer
    Public ThreeChanceFrom As Integer
    Public ThreeChanceTo As Integer
    Public SingleChanceFrom As Integer
    Public SingleChanceTo As Integer
    Public DoubleChanceFrom As Integer
    Public DoubleChanceTo As Integer
    Public FourChanceFrom As Integer
    Public FourChanceTo As Integer
    Public SixChanceFrom As Integer
    Public SixChanceTo As Integer
    Public WicketChanceFrom As Integer
    Public WicketChanceTo As Integer
    '#Region "Event Procedures"
    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        TypeofPitch = Randomizer.Next(3) + 3
        ScoreArea.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        btnBat.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        btnBowl.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        CustomArea.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        'Windows.Storage.ApplicationData.Current.RoamingSettings.Values.Clear()
        If Not RoamSet.Values.ContainsKey("GamesInHistory") Then
            RoamSet.values("GamesInHistory") = 0
        End If
        GamesInHistory = RoamSet.values("GamesInHistory")
        If GamesInHistory <> 0 Then
            For HistoryNum As Integer = GamesInHistory To 1 Step -1
                TempStr = "History" & HistoryNum
                HistoryCS = HistoryCS & RoamSet.values(TempStr)
            Next
        End If
        'Full Members
        t1.Items.Add("India")           '1+3+3=7
        t1.Items.Add("England")         '2+2+5=9
        t1.Items.Add("South Africa")    '4+1+6=11
        t1.Items.Add("Sri Lanka")       '5+6+1=12
        t1.Items.Add("Australia")       '3+4+7=14
        t1.Items.Add("Pakistan")        '6+5+4=15
        t1.Items.Add("West Indies")     '7+7+2=16
        t1.Items.Add("New Zealand")     '8+8+8=24
        t1.Items.Add("Bangladesh")      '9+9+10=28
        t1.Items.Add("Zimbabwe")        '10+10+11=31    Zimbabwe is listed before Ireland because it is a full ICC member while Ireland is an associate member.
        'Top Associate/Affiliate Members
        t1.Items.Add("Ireland")         '11+10+9=30
        t1.Items.Add("Netherlands")     '12+10+12=34
        t1.Items.Add("Kenya")           '13+10+13=36
        t1.Items.Add("Afghanistan")     '14
        t1.Items.Add("Scotland")        '15
        t1.Items.Add("Canada")          '16
        'Other Associate Members
        t1.Items.Add("Argentina")
        t1.Items.Add("Belgium")
        t1.Items.Add("Bermuda")
        t1.Items.Add("Botswana")
        t1.Items.Add("Cayman Islands")
        t1.Items.Add("Denmark")
        t1.Items.Add("Fiji")
        t1.Items.Add("France")
        t1.Items.Add("Germany")
        t1.Items.Add("Gibraltar")
        t1.Items.Add("Guernsey")
        t1.Items.Add("Hong Kong")
        t1.Items.Add("Israel")
        t1.Items.Add("Italy")
        t1.Items.Add("Japan")
        t1.Items.Add("Jersey")
        t1.Items.Add("Kuwait")
        t1.Items.Add("Malaysia")
        t1.Items.Add("Namibia")
        t1.Items.Add("Nepal")
        t1.Items.Add("Nigeria")
        t1.Items.Add("Papua New Guinea")
        t1.Items.Add("Singapore")
        t1.Items.Add("Suriname")
        t1.Items.Add("Tanzania")
        t1.Items.Add("Thailand")
        t1.Items.Add("Uganda")
        t1.Items.Add("United Arab Emirates")
        t1.Items.Add("United States")
        t1.Items.Add("Vanuatu")
        t1.Items.Add("Zambia")
        'Affiliate Members
        t1.Items.Add("Austria")
        t1.Items.Add("Bahamas")
        t1.Items.Add("Bahrain")
        t1.Items.Add("Belize")
        t1.Items.Add("Bhutan")
        t1.Items.Add("Brazil")
        t1.Items.Add("Brunei")
        t1.Items.Add("Bulgaria")
        t1.Items.Add("Cameroon")
        t1.Items.Add("Chile")
        t1.Items.Add("China")
        t1.Items.Add("Cook Islands")
        t1.Items.Add("Costa Rica")
        t1.Items.Add("Croatia")
        t1.Items.Add("Cuba")
        t1.Items.Add("Cyprus")
        t1.Items.Add("Czech Republic")
        t1.Items.Add("Estonia")
        t1.Items.Add("Falkland Islands")
        t1.Items.Add("Finland")
        t1.Items.Add("Gambia")
        t1.Items.Add("Ghana")
        t1.Items.Add("Greece")
        t1.Items.Add("Hungary")
        t1.Items.Add("Indonesia")
        t1.Items.Add("Iran")
        t1.Items.Add("Isle of Man")
        t1.Items.Add("Lesotho")
        t1.Items.Add("Luxembourg")
        t1.Items.Add("Malawi")
        t1.Items.Add("Maldives")
        t1.Items.Add("Mali")
        t1.Items.Add("Malta")
        t1.Items.Add("Mexico")
        t1.Items.Add("Morocco")
        t1.Items.Add("Mozambique")
        t1.Items.Add("Myanmar")
        t1.Items.Add("Norway")
        t1.Items.Add("Oman")
        t1.Items.Add("Panama")
        t1.Items.Add("Peru")
        t1.Items.Add("Philippines")
        t1.Items.Add("Portugal")
        t1.Items.Add("Qatar")
        t1.Items.Add("Russia")
        t1.Items.Add("Rwanda")
        t1.Items.Add("Saint Helena")
        t1.Items.Add("Samoa")
        t1.Items.Add("Saudi Arabia")
        t1.Items.Add("Saychelles")
        t1.Items.Add("Sierra Leone")
        t1.Items.Add("Slovenia")
        t1.Items.Add("South Korea")
        t1.Items.Add("Spain")
        t1.Items.Add("Swaziland")
        t1.Items.Add("Sweden")
        t1.Items.Add("Tonga")
        t1.Items.Add("Turkey")
        t1.Items.Add("Turks and Caicos Islands")
        'Former Affiliate Members
        t1.Items.Add("Switzerland")
        'Non-Members
        t1.Items.Add("Belarus")
        t1.Items.Add("Cambodia")
        t1.Items.Add("Colombia")
        t1.Items.Add("Ecuador")
        t1.Items.Add("Egypt")
        t1.Items.Add("El Salvador")
        t1.Items.Add("Kiribati")
        t1.Items.Add("Latvia")
        t1.Items.Add("Lithuania")
        t1.Items.Add("Macedonia")
        t1.Items.Add("Mauritius")
        t1.Items.Add("New Caledonia")
        t1.Items.Add("Nicaragua")
        t1.Items.Add("Poland")
        t1.Items.Add("Romania")
        t1.Items.Add("Serbia")
        t1.Items.Add("Slovakia")
        t1.Items.Add("Solomon Islands")
        t1.Items.Add("Taiwan")
        t1.Items.Add("Tajikistan")
        t1.Items.Add("Tuvalu")
        t1.Items.Add("Ukraine")
        t1.Items.Add("Uruguay")
        For TempNum As Integer = 0 To t1.Items.Count - 1
            t2.Items.Add(t1.Items.Item(TempNum))
        Next
        t3.Items.Add("50 overs One Day International")
        t3.Items.Add("20 overs Twenty20 International")
        t3.Items.Add("10 overs Ten10 International")
        BallAs.Items.Add("Legitimate")
        BallAs.Items.Add("Over-Stepped")
        BallAs.Items.Add("Beamer")
        BallAs.Items.Add("Wide Ball")
        BallAs.Items.Add("Not Bowled")
        BallAs.Items.Add("Start Rain")
        BallAs.Items.Add("Bad Lights")
        For TempNum As Integer = 0 To 5
            AddExt.Items.Add(TempNum)
        Next
        For TempNum As Integer = 0 To 9
            AddRun.Items.Add(TempNum)
        Next
        RunAs.Items.Add("Bat")
        RunAs.Items.Add("Body")
        RunAs.Items.Add("Free")
        PlayRandX.Items.Add("1x")
        PlayRandX.Items.Add("10x")
        PlayRandX.Items.Add("25x")
        PlayRandX.Items.Add("50x")
        PlayRandX.Items.Add("100x")
        t1.SelectedIndex = 0
        t2.SelectedIndex = 1
        t3.SelectedIndex = 1
        BallAs.SelectedIndex = 0
        AddExt.SelectedIndex = 0
        AddRun.SelectedIndex = 0
        RunAs.SelectedIndex = 0
        PlayRandX.SelectedIndex = 0
    End Sub
    Private Sub AddExt_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles AddExt.SelectionChanged
        If AddExt.SelectedIndex > AddRun.SelectedIndex Then
            AddRun.SelectedIndex = AddExt.SelectedIndex
        End If
        If AddExt.SelectedIndex = 0 Then
            RunAs.SelectedIndex = 0
        End If
    End Sub
    Private Sub AddRun_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles AddRun.SelectionChanged
        If AddRun.SelectedIndex < AddExt.SelectedIndex Then
            AddExt.SelectedIndex = AddRun.SelectedIndex
        End If
    End Sub
    Private Sub AddtoGame_Click(sender As Object, e As RoutedEventArgs) Handles AddtoGame.Click
        NewRun = 0
        NewExt = 0
        NewWkt = 0
        tgbCustom.IsChecked = False
        tgbCustom.Focus(Windows.UI.Xaml.FocusState.Pointer)
        If Balls Mod 6 = 0 And ThisOverBar.Text <> "" Then
            If ThisOverBar.Text.Length > 11 Then
                ThisOverBar.Text = ""
            End If
        End If
        If ThisOverBar.Text.Length > 20 Then
            ThisOverBar.Text = ""
        End If
        If BallAs.SelectedIndex = 5 Then
            If txtComment.Text <> "Commentary [Optional]" Then
                Update2.Text = txtComment.Text
            Else
                Update2.Text = "It has started raining. Match stopped due to heavy rain."
            End If
            AddNewComment(vbNewLine & "Well well well! It has started raining heavily and the covers has been brought. The match cannot progress, says the field umpires. The crowd must be cursing their gods for the spoilsport hence caused." & vbNewLine)
            ShowResult()
            Exit Sub
        ElseIf BallAs.SelectedIndex = 6 Then
            If txtComment.Text <> "Commentary [Optional]" Then
                Update2.Text = txtComment.Text
            Else
                Update2.Text = "Insufficient light. Match stopped due to bad lights."
            End If
            AddNewComment(vbNewLine & "The players have been complaining since long that they are unable to see the ball because of bad lights. Now, the umpires have declared that the match has to be stopped. The crowd is angry about the cricket ground management. Well, it looks like a day wasted now." & vbNewLine)
            ShowResult()
            Exit Sub
        End If
        If txtComment.Text = "Commentary [Optional]" Then
            If AddWkt.IsChecked = True Then
                BallResult = "W"
            ElseIf BallAs.SelectedIndex = 3 And AddRun.SelectedIndex = 6 Then
                BallResult = "4wd"
            ElseIf BallAs.SelectedIndex = 3 Then
                BallResult = "wd"
            ElseIf BallAs.SelectedIndex = 1 Then
                BallResult = "nb"
            ElseIf BallAs.SelectedIndex = 2 Then
                BallResult = "b"
            ElseIf BallAs.SelectedIndex = 4 Then
                BallResult = "db"
            ElseIf BallAs.SelectedIndex = 0 And AddRun.SelectedIndex = 0 Then
                BallResult = "dot"
            ElseIf BallAs.SelectedIndex = 0 And RunAs.SelectedIndex > 0 Then
                BallResult = "a/f"
            ElseIf AddRun.SelectedIndex = 1 Then
                BallResult = "1"
            ElseIf AddRun.SelectedIndex = 2 Then
                BallResult = "2"
            ElseIf AddRun.SelectedIndex = 3 Then
                BallResult = "3"
            ElseIf AddRun.SelectedIndex = 4 Then
                BallResult = "4"
            ElseIf AddRun.SelectedIndex = 5 Then
                BallResult = "5"
            ElseIf AddRun.SelectedIndex = 6 Then
                BallResult = "6"
            Else
                BallResult = "n/a"
            End If
            NewRun = AddRun.SelectedIndex
            NewExt = AddExt.SelectedIndex
            If AddWkt.IsChecked = True Then
                NewWkt = 1
            End If
            RandomCommentary(BallResult, True)
        Else
            CalcLastBall()
            If BallAs.SelectedIndex > 0 Then
                NotBowled = True
            Else
                NotBowled = False
            End If
            BallResult = txtComment.Text
            NewRun = AddRun.SelectedIndex
            NewExt = AddExt.SelectedIndex
            If AddWkt.IsChecked = True Then
                NewWkt = 1
            End If
            txtComment.Text = "Commentary [Optional]"
        End If
        PostBall()
    End Sub
    Private Sub BallAs_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles BallAs.SelectionChanged
        If BallAs.SelectedIndex > 4 Then
            AddRun.IsEnabled = False
            AddExt.IsEnabled = False
            AddWkt.IsChecked = False
            AddWkt.IsEnabled = False
            RunAs.IsEnabled = False
        Else
            AddRun.IsEnabled = True
            AddExt.IsEnabled = True
            AddWkt.IsEnabled = True
            RunAs.IsEnabled = True
        End If
        If BallAs.SelectedIndex = 3 Then
            RunAs.SelectedIndex = 2
            RunAs.IsEnabled = False
        ElseIf BallAs.SelectedIndex < 3 Then
            RunAs.SelectedIndex = 0
            RunAs.IsEnabled = True
        End If
        If BallAs.SelectedIndex > 0 And BallAs.SelectedIndex < 4 Then
            AddExt.SelectedIndex = 1
        Else
            AddExt.SelectedIndex = 0
        End If
    End Sub
    Private Async Sub btnAction_Click(sender As Object, e As RoutedEventArgs) Handles btnAction.Click
        If PlayRandX.SelectedIndex = 0 Then
            btnActionCmds()
        Else
            Select Case PlayRandX.SelectedIndex
                Case 1
                    For TempNum As Integer = 1 To 10
                        If Not btnAction.IsEnabled Then
                            Exit For
                        Else
                            btnActionCmds()
                            Await Task.Delay(100)
                        End If
                    Next
                Case 2
                    For TempNum As Integer = 1 To 25
                        If Not btnAction.IsEnabled Then
                            Exit For
                        Else
                            btnActionCmds()
                            Await Task.Delay(100)
                        End If
                    Next
                Case 3
                    For TempNum As Integer = 1 To 50
                        If Not btnAction.IsEnabled Then
                            Exit For
                        Else
                            btnActionCmds()
                            Await Task.Delay(100)
                        End If
                    Next
                Case 4
                    For TempNum As Integer = 1 To 100
                        If Not btnAction.IsEnabled Then
                            Exit For
                        Else
                            btnActionCmds()
                            Await Task.Delay(100)
                        End If
                    Next
            End Select
        End If
    End Sub
    Private Sub btnBat_Click(sender As Object, e As RoutedEventArgs) Handles btnBat.Click
        Decis = "bat"
        TossResult.Text = TossResult.Text & " and chose to bat"
        TempNum = Randomizer.Next(4)
        Select Case TempNum
            Case 0 : AddNewComment("Looks like " & TossW & " are going to bat first.")
            Case 1 : AddNewComment("They want to bat first, put a big score on the board and then resist their opponents from doing the same.")
            Case 2 : AddNewComment("Batting first is always a symbol of confidence.")
            Case 3
                Select Case TypeofPitch
                    Case 3 : AddNewComment("Great decision to be batting first on a batting pitch.")
                    Case 4 : AddNewComment(TossW & " have decided to bat first. But it doesn't really matter who bat first on this pitch. It is always a tough contest.")
                    Case 5 : AddNewComment("Batting first on a bowling pitch! That scares me a bit!")
                End Select
        End Select
        btnBat.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        btnBowl.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        btnStart.Visibility = Windows.UI.Xaml.Visibility.Visible
        btnStart.Focus(Windows.UI.Xaml.FocusState.Pointer)
    End Sub
    Private Sub btnBowl_Click(sender As Object, e As RoutedEventArgs) Handles btnBowl.Click
        Decis = "bowl"
        TossResult.Text = TossResult.Text & " and chose to bowl"
        TempNum = Randomizer.Next(4)
        Select Case TempNum
            Case 0 : AddNewComment("Looks like " & TossW & " are going to bowl first.")
            Case 1 : AddNewComment("They want to bowl first, restrict the opponents to a small score, and then chase the same to win.")
            Case 2 : AddNewComment("Bowling first is always a symbol of having faith in bowlers and confidence in batsman.")
            Case 3
                Select Case TypeofPitch
                    Case 3 : AddNewComment("Strange decision to be bowling first on a batting pitch. There must be an undercover plan in " & CaptainName(TossW) & "'s mind.")
                    Case 4 : AddNewComment(TossW & " have decided to bowl first. But it doesn't really matter what you choose on this pitch. It is always a tough contest.")
                    Case 5 : AddNewComment("Great decision to be bowling first on a bowling pitch.")
                End Select
        End Select
        btnBat.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        btnBowl.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        btnStart.Visibility = Windows.UI.Xaml.Visibility.Visible
        btnStart.Focus(Windows.UI.Xaml.FocusState.Pointer)
    End Sub
    Private Sub btnCopyCom_Click(sender As Object, e As RoutedEventArgs) Handles btnCopyCom.Click
        DatPack.SetText(FullCommentary)
        Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(DatPack)
    End Sub
    Private Sub btnDelHis_Click(sender As Object, e As RoutedEventArgs) Handles btnDelHis.Click
        Windows.Storage.ApplicationData.Current.RoamingSettings.Values.Clear()
        GamesInHistory = 0
        HistoryCS = ""
        If tgbHistory.IsChecked = True Then
            txtRight.Text = HistoryCS
        End If
    End Sub
    Private Sub btnStart_Click(sender As Object, e As RoutedEventArgs) Handles btnStart.Click
        If btnStart.Content = "Flip Coin" Then
            TempNum = Randomizer.Next(2)
            If TempNum = 0 Then
                TossW = t1.SelectedItem
                TossL = t2.SelectedItem
            Else
                TossW = t2.SelectedItem
                TossL = t1.SelectedItem
            End If
            TossResult.Text = TossW & " won the toss"
            TempNum = Randomizer.Next(3)
            If CaptainName(TossW) = "the captain" Then
                TempNum = 1
            End If
            Select Case TempNum
                Case 0 : AddNewComment(CaptainName(TossW) & " has won the toss." & vbNewLine)
                Case 1 : AddNewComment(TossW & " wins the toss." & vbNewLine)
                Case 2 : AddNewComment(CaptainName(TossW) & " has always been lucky. Once again, winning the toss for " & TossW & "." & vbNewLine)
            End Select
            btnStart.Content = "Start Match"
            btnStart.Visibility = Windows.UI.Xaml.Visibility.Collapsed
            btnBat.Visibility = Windows.UI.Xaml.Visibility.Visible
            btnBowl.Visibility = Windows.UI.Xaml.Visibility.Visible
            t1.IsEnabled = False
            t2.IsEnabled = False
            t3.IsEnabled = False
            btnBat.Focus(Windows.UI.Xaml.FocusState.Pointer)
        ElseIf btnStart.Content = "Start Match" Then
            ScoreArea.Visibility = Windows.UI.Xaml.Visibility.Visible
            Select Case TypeofPitch
                Case 3 : Update1.Text = "Pitch might favor batting"
                Case 4 : Update1.Text = "Expect a great contest of bat and ball"
                Case 5 : Update1.Text = "Wet bowling pitch today"
            End Select
            If Decis = "bat" Then
                BattingTeam.Text = TossW
                BowlingTeam = TossL
            Else
                BattingTeam.Text = TossL
                BowlingTeam = TossW
            End If
            InningNum = 1
            btnStart.Content = "Reset"
            btnAction.IsEnabled = True
            tgbCustom.IsEnabled = True
            PlayRandX.Visibility = Windows.UI.Xaml.Visibility.Visible
            btnAction.Focus(Windows.UI.Xaml.FocusState.Pointer)
            Select Case TypeofPitch
                Case 3 : AddNewComment(vbNewLine & BattingTeam.Text & " is ready for a flying start.")
                Case 4 : AddNewComment(vbNewLine & BattingTeam.Text & " would want to put a good score on the board.")
                Case 5 : AddNewComment(vbNewLine & "Is " & BattingTeam.Text & " really prepared for the flood of wickets?")
            End Select
            RequiredRate = ((4 + (2 * (5 - TypeofPitch))) / 100) * (80 + ((300 - TotalBalls) / 3))
            WASPscore = GetWASPscore()
            WASP.Text = WASPscore
            'If RemBalls < TotalBalls - Balls Then
            '    RequiredRate -= 5 / TotalBalls
            'Else
            '    If WASPscore > (TotalBalls / 100) * (80 + ((300 - TotalBalls) / 3)) Then
            '        RequiredRate += 5 / TotalBalls
            '    End If
            'End If
        Else
            ScoreArea.Visibility = Windows.UI.Xaml.Visibility.Collapsed
            btnBat.Visibility = Windows.UI.Xaml.Visibility.Collapsed
            btnBowl.Visibility = Windows.UI.Xaml.Visibility.Collapsed
            TypeofPitch = Randomizer.Next(3) + 3
            btnStart.Content = "Flip Coin"
            t1.IsEnabled = True
            t2.IsEnabled = True
            t3.IsEnabled = True
            t1.Focus(Windows.UI.Xaml.FocusState.Pointer)
            btnBat.Visibility = Windows.UI.Xaml.Visibility.Collapsed
            btnBowl.Visibility = Windows.UI.Xaml.Visibility.Collapsed
            TossResult.Text = ""
            Runs = 0
            Wickets = 0
            Balls = 0
            WktCont = 0
            WktCont2 = 0
            Score.Text = "0/0"
            Overs.Text = "0"
            RunRate.Text = "0"
            WASP.Text = "0"
            Extras.Text = "0"
            ThisOverBar.Text = ""
            LastBall = ""
            Tgt = 0
            RunsBeforeOver = 0
            WicketsBeforeOver = 0
            Update2.Text = ""
            Update1.Text = ""
            btnAction.Content = "Play Random"
            PreMatch()
        End If
    End Sub
    Private Sub RunAs_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles RunAs.SelectionChanged
        If RunAs.SelectedIndex > 0 Then
            AddExt.SelectedIndex = AddRun.SelectedIndex
        End If
    End Sub
    Private Sub t1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles t1.SelectionChanged
        If CaptainName(t1.SelectedItem) <> "the captain" Then
            c1.Text = "led by " & CaptainName(t1.SelectedItem)
        Else
            c1.Text = ""
        End If
        If t1.SelectedItem = t2.SelectedItem Then
            btnStart.IsEnabled = False
            FullCommentary = ""
            AddComment("Please select two different teams to play.")
        Else
            btnStart.IsEnabled = True
            PreMatch()
        End If
    End Sub
    Private Sub t2_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles t2.SelectionChanged
        If CaptainName(t2.SelectedItem) <> "the captain" Then
            c2.Text = "led by " & CaptainName(t2.SelectedItem)
        Else
            c2.Text = ""
        End If
        If t1.SelectedItem = t2.SelectedItem Then
            btnStart.IsEnabled = False
            FullCommentary = ""
            AddComment("Please select two different teams to play.")
        Else
            btnStart.IsEnabled = True
            PreMatch()
        End If
    End Sub
    Private Sub t3_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles t3.SelectionChanged
        Select Case t3.SelectedIndex
            Case 0 : TotalBalls = 300
            Case 1 : TotalBalls = 120
            Case 2 : TotalBalls = 60
        End Select
        If t1.SelectedItem <> t2.SelectedItem Then
            btnStart.IsEnabled = True
            PreMatch()
        End If
    End Sub
    Private Sub tgbComment_Checked(sender As Object, e As RoutedEventArgs) Handles tgbComment.Checked
        tgbHistory.IsChecked = False
        tgbHelp.IsChecked = False
        txtRight.Text = FullCommentary
        tgbComment.IsEnabled = False
    End Sub
    Private Sub tgbComment_Unchecked(sender As Object, e As RoutedEventArgs) Handles tgbComment.Unchecked
        tgbComment.IsEnabled = True
    End Sub
    Private Sub tgbCustom_Checked(sender As Object, e As RoutedEventArgs) Handles tgbCustom.Checked
        ScoreBoardArea.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        CustomArea.Visibility = Windows.UI.Xaml.Visibility.Visible
        AddtoGame.Focus(Windows.UI.Xaml.FocusState.Pointer)
    End Sub
    Private Sub tgbCustom_Unchecked(sender As Object, e As RoutedEventArgs) Handles tgbCustom.Unchecked
        ScoreBoardArea.Visibility = Windows.UI.Xaml.Visibility.Visible
        CustomArea.Visibility = Windows.UI.Xaml.Visibility.Collapsed
    End Sub
    Private Sub tgbHelp_Checked(sender As Object, e As RoutedEventArgs) Handles tgbHelp.Checked
        tgbComment.IsChecked = False
        tgbHistory.IsChecked = False
        txtRight.Text = HelpText
        tgbHelp.IsEnabled = False
        tgbComment.Focus(Windows.UI.Xaml.FocusState.Pointer)
    End Sub
    Private Sub tgbHelp_Unchecked(sender As Object, e As RoutedEventArgs) Handles tgbHelp.Unchecked
        tgbHelp.IsEnabled = True
    End Sub
    Private Sub tgbHistory_Checked(sender As Object, e As RoutedEventArgs) Handles tgbHistory.Checked
        tgbComment.IsChecked = False
        tgbHelp.IsChecked = False
        txtRight.Text = HistoryCS
        tgbHistory.IsEnabled = False
    End Sub
    Private Sub tgbHistory_Unchecked(sender As Object, e As RoutedEventArgs) Handles tgbHistory.Unchecked
        tgbHistory.IsEnabled = True
    End Sub
    Private Sub txtComment_GotFocus(sender As Object, e As RoutedEventArgs) Handles txtComment.GotFocus
        If txtComment.Text = "Commentary [Optional]" Then
            txtComment.Text = ""
        End If
    End Sub
    Private Sub txtComment_LostFocus(sender As Object, e As RoutedEventArgs) Handles txtComment.LostFocus
        If txtComment.Text = "" Then
            txtComment.Text = "Commentary [Optional]"
        End If
    End Sub
    Private Sub txtRight_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtRight.TextChanged
        If txtRight.Text = "" Then
            If tgbHistory.IsChecked = True Then
                txtRight.Text = "NO HISTORY TO DISPLAY" & vbNewLine & vbNewLine & "There were no match results in the records. Finish a match to add its summary to history."
            ElseIf tgbComment.IsChecked = True Then
                txtRight.Text = "NO COMMENTARY TO DISPLAY" & vbNewLine & vbNewLine & "Something went wrong while trying to fetch the commentary from commentators. If problem persists, please re-install Cricket Simulator or contact support@anico.in for relevant support."
            ElseIf tgbHelp.IsChecked = True Then
                txtRight.Text = "NO HELP TO DISPLAY" & vbNewLine & vbNewLine & "Something went wrong while trying to read from manuals. If problem persists, please re-install Cricket Simulator or contact support@anico.in for relevant support."
            End If
        End If
    End Sub
    '#End Region
    '#Region "User Procedures"
    Public Sub AddComment(Commentary As String)
        FullCommentary = FullCommentary & vbNewLine & Commentary
        If tgbComment.IsChecked = True Then
            txtRight.Text = FullCommentary
        End If
    End Sub
    Public Sub AddNewComment(Commentary As String)
        FullCommentary = Commentary & vbNewLine & FullCommentary
        If tgbComment.IsChecked = True Then
            txtRight.Text = FullCommentary
        End If
    End Sub
    Public Sub CalcLastBall()
        Select Case BallAs.SelectedIndex
            Case 0
                If AddWkt.IsChecked Then
                    If AddRun.SelectedIndex > 0 Then
                        LastBall = AddRun.SelectedIndex & "W"
                    Else
                        LastBall = "W"
                    End If
                ElseIf AddExt.SelectedIndex > 0 Then
                    If RunAs.SelectedIndex = 1 Then
                        LastBall = AddRun.SelectedIndex & "lb"
                    Else
                        LastBall = AddRun.SelectedIndex & "b"
                    End If
                Else
                    LastBall = AddRun.SelectedIndex
                End If
            Case 1, 2
                If AddWkt.IsChecked Then
                    If AddRun.SelectedIndex > 0 Then
                        LastBall = AddRun.SelectedIndex & "W"
                    Else
                        LastBall = "W"
                    End If
                Else
                    LastBall = (AddRun.SelectedIndex - 1) & "nb"
                End If
            Case 3
                If AddWkt.IsChecked Then
                    If AddRun.SelectedIndex > 0 Then
                        LastBall = AddRun.SelectedIndex & "W"
                    Else
                        LastBall = "W"
                    End If
                Else
                    LastBall = (AddRun.SelectedIndex - 1) & "wd"
                End If
            Case 4, 5, 6
                LastBall = ""
        End Select
    End Sub
    Public Sub NewInning()
        FirstInning = BattingTeam.Text & ": " & Score.Text & " in " & Overs.Text & " overs"
        btnAction.Content = "Next Inning"
        tgbCustom.IsEnabled = False
        PlayRandX.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        Select Case ExpectedScore
            Case Is > Runs + 15 : AddNewComment(vbNewLine & "Very disappointing performance from " & BattingTeam.Text & ". The bowlers dominated throughout the game restricting " & BattingTeam.Text & " to a score of " & Runs & ". Now their aim is to come out to bat and finish this game in style." & vbNewLine)
            Case Is < Runs - 15 : AddNewComment(vbNewLine & "Wow! Well played " & BattingTeam.Text & ". The score on the board is clearly telling us the story how the bowlers have been thrashed by the fearless batsman. The target of " & Runs + 1 & " doesn't look easy at all." & vbNewLine)
            Case Else : AddNewComment(vbNewLine & "They should be happy with whatever they've got. The pitch played as expected. That's all we had in the first innings. " & BattingTeam.Text & " has set a target of " & Runs + 1 & " runs for " & BowlingTeam & "." & vbNewLine)
        End Select
    End Sub
    Public Sub PostBall()
        If LastBall <> "" Then
            ThisOverBar.Text = ThisOverBar.Text & " " & LastBall
        End If
        Update1.Text = BallResult
        Runs = Runs + NewRun
        If NewWkt = 0 And LastBall <> "" And WktIndex <> 1 And WktIndex <> 2 And WktIndex <> 3 And WktIndex <> 5 And WktIndex <> 7 Then
            WktCont = 0
        Else
            Wickets = Wickets + NewWkt
        End If
        Extras.Text = Extras.Text + NewExt
        If NotBowled Then
            AddNewComment(vbTab & LastBall & vbTab & Update1.Text)
        Else
            Balls += 1
            If Balls Mod 6 = 0 Then
                Overs.Text = Balls / 6
                AddNewComment(((Balls / 6) - 1) & ".6" & vbTab & LastBall & vbTab & Update1.Text)
            Else
                Overs.Text = Math.Floor(Balls / 6) & "." & (Balls Mod 6)
                AddNewComment(Overs.Text & vbTab & LastBall & vbTab & Update1.Text)
            End If
            FreeHit = False
        End If
        If WktCont = 5 Then
            AddNewComment(vbTab & vbTab & "A triple hat-trick! Ultra-rare!")
        ElseIf WktCont = 4 Then
            AddNewComment(vbTab & vbTab & "A double hat-trick! Superskilled!")
        ElseIf WktCont = 3 Then
            AddNewComment(vbTab & vbTab & "A Hat-trick! Splendid!")
        ElseIf WktCont = 2 And Balls Mod 6 <> 0 And Wickets < 10 Then
            AddNewComment(vbTab & vbTab & "Fielders all around the batsman for this Hat-trick chance")
        End If
        If Balls <> 0 Then
            RunRate.Text = Math.Round(Runs * 6 / Balls, 2)
        Else
            RunRate.Text = "0"
        End If
        WASPscore = GetWASPscore()
        If InningNum = 1 Then
            WASP.Text = WASPscore
            If Balls Mod 6 = 0 Then
                If RemBalls < TotalBalls - Balls Then
                    RequiredRate -= 6 / TotalBalls
                Else
                    If WASPscore > (TotalBalls / 100) * (80 + ((300 - TotalBalls) / 3)) And RequiredRate < (4 + (240 - TotalBalls) / 60 + 2 * (5 - TypeofPitch)) + (Balls * 5 / TotalBalls) Then
                        RequiredRate += 6 / TotalBalls
                    End If
                End If
            End If
        Else
            Dim WASPpercent As Integer
            If WASPscore > Tgt1 Then
                WASPpercent = Math.Round(75 + (WASPscore - Tgt) * (Balls / TotalBalls), 0)
            ElseIf WASPscore < Tgt2 Then
                WASPpercent = Math.Round(25 + (WASPscore - Tgt) * (Balls / TotalBalls), 0)
            ElseIf Runs >= Tgt Then
                WASPpercent = 100
            Else
                WASPpercent = Math.Round(50 + (WASPscore - Tgt) * 10 * (Balls / TotalBalls), 0)
            End If
            If WASPpercent > 100 Then
                WASP.Text = "100"
            ElseIf WASPpercent < 0 Then
                WASP.Text = "0"
            Else
                WASP.Text = WASPpercent
            End If
            WASP.Text = WASP.Text & "% (Tgt " & Tgt & ")"
            RequiredRate = Math.Round((Tgt - Runs) * 6 / (TotalBalls - Balls), 2)
            If (Tgt - Runs) * 6 / (TotalBalls - Balls) > 36 Then
                Update2.Text = BowlingTeam & " need to avoid extra runs to win"
            ElseIf (WASPscore < Tgt2) And RemBalls < TotalBalls - Balls Then
                Update2.Text = BowlingTeam & " need " & WriteStr((10 - Wickets), "wicket") & " to win"
            ElseIf (WASPscore > Tgt1) Then
                Update2.Text = BattingTeam.Text & " need " & WriteStr((Tgt - Runs), "run") & " to win"
            Else
                If RemBalls < TotalBalls - Balls Then
                    Update2.Text = BattingTeam.Text & " need " & WriteStr((Tgt - Runs), "run") & " with " & WriteStr(10 - Wickets, "wicket") & " in hand"
                Else
                    Update2.Text = BattingTeam.Text & " need " & WriteStr((Tgt - Runs), "run") & " in " & WriteStr(TotalBalls - Balls, "ball") & " at " & WriteStr(RequiredRate, "run") & " per over"
                End If
            End If
        End If
        If Wickets = 10 Then
            Score.Text = Runs
            Update2.Text = BattingTeam.Text & " is all out for " & WriteStr(Runs, "run") & "."
            AddNewComment(Update2.Text & vbNewLine)
            If InningNum = 1 Then
                NewInning()
            Else
                ShowResult()
            End If
            Exit Sub
        Else
            Score.Text = Runs & "/" & Wickets
        End If
        If Runs >= Tgt And InningNum = 2 Then
            AddNewComment("Winning runs coming in the form of " & LastBall & "." & vbNewLine)
            ShowResult()
            Exit Sub
        End If
        If Balls = TotalBalls Then
            Update2.Text = "Overs up. " & BattingTeam.Text & " made " & WriteStr(Runs, "run") & " for " & WriteStr(Wickets, "wicket") & "."
            AddNewComment(Update2.Text & vbNewLine)
            If InningNum = 1 Then
                NewInning()
            Else
                ShowResult()
            End If
            Exit Sub
        End If
        If Not NotBowled Then   'Special Comments Below
            If Balls Mod 6 = 0 Then 'If last ball of the over
                If Wickets - WicketsBeforeOver > 1 And Runs - RunsBeforeOver > 9 + (300 - TotalBalls) / 40 Then
                    AddNewComment(vbNewLine & "End of a mixed over. A cookie for everyone in it. " & BattingTeam.Text & " are " & Runs & " for " & Wickets & "." & vbNewLine)
                ElseIf Wickets - WicketsBeforeOver > 1 Then
                    AddNewComment(vbNewLine & "Magnificent over for the bowling side! " & WriteStr((Wickets - WicketsBeforeOver), "wicket") & " in this over." & vbNewLine)
                ElseIf RunsBeforeOver = Runs Then
                    If Wickets - WicketsBeforeOver > 0 Then
                        AddNewComment(vbNewLine & "Maiden Over! " & WriteStr((Wickets - WicketsBeforeOver), "wicket") & " in this over as well." & vbNewLine)
                    Else
                        AddNewComment(vbNewLine & "Excellent Maiden Over! " & BattingTeam.Text & " might not be able to cope this momentum change." & vbNewLine)
                    End If
                ElseIf Runs - RunsBeforeOver > 9 + (300 - TotalBalls) / 40 Then
                    AddNewComment(vbNewLine & "That was an expensive over. " & BattingTeam.Text & " scored " & (Runs - RunsBeforeOver) & " runs off it, " & CaptainName(BowlingTeam) & " would like a change in bowling." & vbNewLine)
                ElseIf Runs - RunsBeforeOver < 4 + (300 - TotalBalls) / 90 Then
                    AddNewComment(vbNewLine & "Great over! Only " & WriteStr((Runs - RunsBeforeOver), "run") & " off it." & vbNewLine)
                Else
                    If Wickets = "0" Then
                        AddNewComment(vbNewLine & "End of over number " & (Balls / 6) & ". " & BattingTeam.Text & " are " & Runs & " without loss." & vbNewLine)
                    Else
                        AddNewComment(vbNewLine & "End of over number " & (Balls / 6) & ". " & BattingTeam.Text & " are " & Runs & " for " & Wickets & "." & vbNewLine)
                    End If
                End If
                WicketsBeforeOver = Wickets
                RunsBeforeOver = Runs
                TempNum = WktCont
                WktCont = WktCont2
                If WktCont = 2 And Wickets < 10 Then
                    AddNewComment(vbTab & vbTab & "From the previous over, he is on hat-trick")
                End If
                WktCont2 = TempNum
            End If
        End If
        NotBowled = False
        Exit Sub
    End Sub
    Public Sub PreMatch()
        TempNum = Randomizer.Next(4)
        Select Case TempNum
            Case 0 : FullCommentary = "Welcome to an exciting " & t3.SelectedItem & " thriller between " & t1.SelectedItem & " and " & t2.SelectedItem & "."
            Case 1 : FullCommentary = "We are all here to witness this nail-biting " & t3.SelectedItem & " clash of " & t1.SelectedItem & " and " & t2.SelectedItem & "."
            Case 2 : FullCommentary = "We are back with the one-off " & t3.SelectedItem & " game between " & t1.SelectedItem & " and " & t2.SelectedItem & "."
            Case 3 : FullCommentary = "All eyes are on this fantastic game of " & t1.SelectedItem & " and " & t2.SelectedItem & " " & t3.SelectedItem & "."
        End Select
        ExpectedScore = 0.8 * TotalBalls + 72 - ((TypeofPitch - 3) * TotalBalls / 4)
        ExpectedScore = ExpectedScore / 10
        ExpectedScore = ExpectedScore * 10
        TempNum = Randomizer.Next(3)
        Select Case TempNum
            Case 0
                Select Case TypeofPitch
                    Case 3 : AddComment(vbNewLine & "The surface is hard. There are few cracks on the pitch that might support spin as the game progress. But overall, we expect a huge score on the board on this batting track.")
                    Case 4 : AddComment(vbNewLine & "This is a cricketing pitch. The ball will come nicely on the bat. But this strong wind may provide some swing to the fast bowlers.")
                    Case 5 : AddComment(vbNewLine & "A wet pitch it is for this game. Bowlers should anticipate much from this game. There will be an uneven bounce causing troubles for the batsman.")
                End Select
            Case 1
                Select Case TypeofPitch
                    Case 3 : AddComment(vbNewLine & "The pitch is dry and flat. And there is no grass to show any sign of smile on bowlers' face. Batsmen out of form have a great chance of comeback today.")
                    Case 4 : AddComment(vbNewLine & "A normal unbiased pitch it is. It doesn't really matter who win the toss today. The game may go either side.")
                    Case 5 : AddComment(vbNewLine & "This pitch is a real test of batsman. It has got bounce that might make even the greatest batsman going 'chin dance'. The captain winning the toss has to bowl first.")
                End Select
            Case 2
                Select Case TypeofPitch
                    Case 3 : AddComment(vbNewLine & "This is a batting surface. Crowd will be delighted to see some big hittings off the bowlers for 4s and 6s. Scores of even " & ExpectedScore & "-" & (ExpectedScore + 10) & " might not be enough.")
                    Case 4 : AddComment(vbNewLine & "On an average track like this, we do not expect a huge score. Something like " & ExpectedScore & "-" & (ExpectedScore + 10) & " might be a good score.")
                    Case 5 : AddComment(vbNewLine & "This track honestly has got nothing for the batsman. Wickets will be falling apart throughout the game. Even the scores of " & ExpectedScore & "-" & (ExpectedScore + 10) & " might prove to be challenging ones.")
                End Select
        End Select
        TempNum = Randomizer.Next(3)
        If CaptainName(t1.SelectedItem) = "the captain" Or CaptainName(t2.SelectedItem) = "the captain" Then
            TempNum = 0
        End If
        Select Case TempNum
            Case 0
                AddComment(vbNewLine & "Both the captains are ready for the toss.")
            Case 1
                AddComment(vbNewLine & CaptainName(t1.SelectedItem) & " and " & CaptainName(t2.SelectedItem) & " along with the match referee are ready for the toss.")
            Case 2
                If TypeofPitch <> 4 Then
                    AddComment(vbNewLine & "Toss might be crucial on a pitch like this. We are ready with " & CaptainName(t1.SelectedItem) & " and " & CaptainName(t2.SelectedItem) & " for the toss.")
                Else
                    AddComment(vbNewLine & "There is not much in the toss really. On the middle, are " & CaptainName(t1.SelectedItem) & " and " & CaptainName(t2.SelectedItem) & " waiting the toss.")
                End If
        End Select
    End Sub
    Public Sub RandomCommentary(ShortResult As String, Optional CustomFig As Boolean = False)
        Select Case ShortResult
            Case "wd"
                TempNum = Randomizer.Next(10)
                NotBowled = True
                If Not CustomFig Then
                    If TempNum = 0 Then
                        NewExt = 1
                        NewRun = 1
                        RandomResult()
                        If WktIndex = 4 Or WktIndex = 5 Or WktIndex = 7 Or WktIndex = 8 Or WktIndex = 9 Then
                            NewWkt = 1
                            NewExt = NewRun + 1
                            NewRun = NewExt
                        Else
                            NewExt = Randomizer.Next(3) + 2
                            NewRun = NewExt
                        End If
                    Else
                        NewExt = 1
                        NewRun = 1
                    End If
                End If
                If NewWkt = 0 Then
                    Select Case NewExt
                        Case 1
                            If TempNum = 1 Then
                                BallResult = "Over batsman's head! Wide"
                            ElseIf TempNum = 2 Then
                                BallResult = "Appealing for caught behind! Wide says the umpire"
                            ElseIf TempNum = 3 Then
                                BallResult = "Way down the leg stump! Wide ball"
                            ElseIf TempNum = 4 Then
                                BallResult = "Out of reach of the batsman, wide ball"
                            Else
                                BallResult = "Wide Ball"
                            End If
                        Case 2
                            BallResult = "Sloppy Keeping! " & WriteStr(NewRun - 1, "wide")
                        Case Else
                            BallResult = "Far away! " & WriteStr(NewRun - 1, "wide")
                    End Select
                    LastBall = CStr(NewRun - 1) & "wd"
                Else
                    LastBall = NewRun & "W"
                End If
            Case "nb"
                NotBowled = True
                FreeHit = True
                If Not CustomFig Then
                    RandomResult(True)
                    If BallResult = "W" Then
                        RandomResult()
                        If WktIndex <> 4 And WktIndex <> 9 And WktIndex <> 8 And WktIndex <> 11 Then
                            BallResult = "0"
                            NewWkt = 0
                        End If
                    ElseIf BallResult = "wd" Or BallResult = "nb" Or BallResult = "5" Or BallResult = "b" Or BallResult = "db" Or BallResult = "a/f" Or BallResult = "4wd" Or BallResult = "dot" Then
                        BallResult = "0"
                    End If
                    If NewWkt = 0 Then
                        NewExt = 1
                        NewRun = NewExt + BallResult
                    End If
                End If
                If NewWkt = 0 Then
                    If NewRun > 1 Then
                        BallResult = WriteStr(NewRun - 1, "run") & " off no ball! FREEHIT on next ball"
                    Else
                        BallResult = "No ball! FREEHIT"
                    End If
                    LastBall = CStr(NewRun - 1) & "nb"
                Else
                    NewExt = 1
                    NewRun = NewRun + 1
                    LastBall = NewRun & "W"
                End If
            Case "b"
                NotBowled = True
                If Not CustomFig Then
                    RandomResult(True)
                    If BallResult = "W" Then
                        RandomResult()
                        If WktIndex <> 4 And WktIndex <> 9 And WktIndex <> 8 And WktIndex <> 11 Then
                            BallResult = "0"
                            NewWkt = 0
                        End If
                    ElseIf BallResult = "wd" Or BallResult = "nb" Or BallResult = "5" Or BallResult = "b" Or BallResult = "db" Or BallResult = "a/f" Or BallResult = "4wd" Or BallResult = "dot" Then
                        BallResult = "0"
                    End If
                    If NewWkt = 0 Then
                        NewExt = 1
                        NewRun = NewExt + BallResult
                    End If
                End If
                If NewWkt = 0 Then
                    If NewRun > 1 Then
                        BallResult = WriteStr(NewRun - 1, "run") & " off BEAMER!"
                    Else
                        BallResult = "Could have been nasty! BEAMER!"
                    End If
                    LastBall = CStr(NewRun - 1) & "nb"
                Else
                    NewExt = 1
                    NewRun = NewRun + 1
                    LastBall = NewRun & "W"
                End If
            Case "4wd"
                NotBowled = True
                TempNum = Randomizer.Next(2)
                If TempNum = 0 Then
                    BallResult = "No chance! 4 wides, " & CaptainName(BowlingTeam) & " looks unhappy"
                Else
                    BallResult = "Over the batsman and the keeper!"
                End If
                NewExt = 5
                NewRun = 5
                LastBall = "4wd"
            Case "db"
                NotBowled = True
                TempNum = Randomizer.Next(4)
                Select Case TempNum
                    Case 0 : BallResult = "Problem with the side screen"
                    Case 1 : BallResult = "Batsman was not ready"
                    Case 2 : BallResult = "Captain is changing the field"
                    Case 3 : BallResult = "Ball is being changed"
                End Select
                LastBall = ""
            Case "5"
                NewRun = 5
                TempNum = Randomizer.Next(100)
                Select Case TempNum
                    Case 47
                        BallResult = "Hits Keeper's Helmet! 5 runs"
                        NewExt = 5
                    Case Else : BallResult = "Overthrows! 5 runs"
                End Select
                LastBall = "5"
            Case "a/f"
                If Not CustomFig Then
                    TempNum = Randomizer.Next(1000)
                    Select Case TempNum
                        Case 0 : NewExt = 4
                        Case 1 : NewExt = 3
                        Case 2 To 50 : NewExt = 2
                        Case 51 To 350 : NewExt = 1
                        Case Else : NewExt = 0
                    End Select
                End If
                NewRun = NewExt
                TempNum = Randomizer.Next(30)
                If NewExt > 0 Then
                    Select Case TempNum
                        Case 0
                            BallResult = "Poor keeping! " & WriteStr(NewExt, "bye")
                            LastBall = CStr(NewExt) & "b"
                        Case 1 To 10
                            BallResult = "Appeal rejected! " & WriteStr(NewExt, "leg bye")
                            LastBall = CStr(NewExt) & "lb"
                        Case Else
                            BallResult = "Hits batsman's pad! " & WriteStr(NewExt, "leg bye")
                            LastBall = CStr(NewExt) & "lb"
                    End Select
                Else
                    If TempNum > 27 Then
                        BallResult = "Out! No! Not given!"
                    ElseIf TempNum > 22 Then
                        BallResult = "Close call. Good decision"
                    ElseIf TempNum > 19 Then
                        BallResult = "A heartless appeal going in favor of batsman"
                    Else
                        BallResult = "Failed to make contact. Hits the pad, no run taken"
                    End If
                    LastBall = "0"
                End If
            Case "3"
                NewRun = 3
                TempNum = Randomizer.Next(2)
                If TempNum Then
                    BallResult = GetFieldShot(True) & ". Good running"
                Else
                    BallResult = GetFieldShot(True) & ". Slow outfield"
                End If
                LastBall = "3"
            Case "1"
                NewRun = 1
                TempNum = Randomizer.Next(100)
                Select Case TempNum
                    Case 0 : BallResult = GetFieldShot(False, "straight to") & ". Direct hit was out!"
                    Case 1 To 20 : BallResult = "Quick single"
                    Case 21 To 40 : BallResult = "Comfortable single"
                    Case 41 To 60 : BallResult = "Nice shot, finds fielder on the boundary. Just 1"
                    Case 61 To 80 : BallResult = GetFieldShot(True, "towards") & ". Easy single"
                    Case Else : BallResult = GetFieldShot(False, "near") & ". Batsman takes 1"
                End Select
                LastBall = "1"
            Case "2"
                NewRun = 2
                TempNum = Randomizer.Next(20)
                Select Case TempNum
                    Case 0 : BallResult = GetFieldShot(False, "near") & ". Misfielding! 2 runs"
                    Case 1 : BallResult = GetFieldShot(False, "over") & ". Catch dropped!"
                    Case 2 To 5 : BallResult = "Quick running! 2 runs"
                    Case 6 To 9 : BallResult = "Wanted 3! Sent back"
                    Case 10 To 13 : BallResult = "Two runs added"
                    Case Else : BallResult = GetFieldShot(True, "down") & ". Batsman takes 2"
                End Select
                LastBall = "2"
            Case "4"
                NewRun = 4
                TempNum = Randomizer.Next(20)
                Select Case TempNum
                    Case 0 : BallResult = "Should have been stopped! 4 runs"
                    Case 1 : BallResult = "Fine shot! 4 runs"
                    Case 2 : BallResult = "Cracking shot! Thrashed away for 4"
                    Case 3 : BallResult = "Beauty! 4 runs"
                    Case 4 To 5 : BallResult = "Into the gap! Gets a boundary"
                    Case 6 To 9 : BallResult = "Classic shot! 4 runs"
                    Case 10 To 11 : BallResult = GetFieldShot(False, "over") & ". One bounce over the rope"
                    Case 12 To 17 : BallResult = GetFieldShot(True, "down") & ". 4 runs"
                    Case Else : BallResult = GetFieldShot(True) & ". Boundary for " & BattingTeam.Text
                End Select
                LastBall = "4"
            Case "6"
                NewRun = 6
                TempNum = Randomizer.Next(10)
                Select Case TempNum
                    Case 0 : BallResult = "Magnificent 6!"
                    Case 1, 2 : BallResult = "Huge! " & CStr(80 + Randomizer.Next(40)) & " metres"
                    Case 3, 4 : BallResult = "Miles in the air! " & CStr(70 + Randomizer.Next(20)) & " metres"
                    Case 5 : BallResult = "Over the bowler's head! 6"
                    Case 6 : BallResult = "Beautiful 6!"
                    Case Else : BallResult = GetFieldShot(True, "over") & ". That's a six"
                End Select
                LastBall = "6"
            Case "W"
                TempNum = Randomizer.Next(1000)
                NewWkt = 1
                LastBall = "W"
                If CustomFig Then
                    TempNum = AddRun.SelectedIndex
                    If BallAs.SelectedIndex <> 0 Then
                        TempNum = TempNum - 1
                    End If
                    Select Case TempNum
                        Case 0
                            If BallAs.SelectedIndex <> 0 Then
                                TempNum = 30
                            Else
                                TempNum = Randomizer.Next(1000)
                                If TempNum >= 20 And TempNum < 71 Then
                                    TempNum = 30
                                End If
                            End If
                        Case 1 : TempNum = 50
                        Case 2 : TempNum = 65
                        Case 3 : TempNum = 21
                    End Select
                End If
                Select Case TempNum
                    Case 0  'Rare kind of dismissals
                        TempNum = Randomizer.Next(1000)
                        Select Case TempNum
                            Case 0
                                BallResult = "Mankaded! Presence of mind!"
                                WktIndex = 12
                                NotBowled = True
                                LastBall = ""
                            Case 1
                                BallResult = "Hit twice! Appealed! Gone!"
                                WktIndex = 11
                            Case 2 To 100
                                If ThisOverBar.Text.EndsWith("W") Then
                                    BallResult = "Batsman could not reach in time! Given out!"
                                    WktIndex = 10
                                    NotBowled = True
                                    LastBall = ""
                                Else
                                    BallResult = "Handled the ball! Out!"
                                    WktIndex = 9
                                End If
                            Case 101 To 200
                                BallResult = "Obstructed the field! Given him!"
                                NewRun = Randomizer.Next(4)
                                If NewRun > 0 Then
                                    LastBall = NewRun & "W"
                                End If
                                WktIndex = 8
                            Case 201 To 400
                                BallResult = "Bastman is given out hit wicket!"
                                WktCont += 1
                                WktIndex = 7
                            Case Else
                                BallResult = "That was nasty! Batsman is retired hurt"
                                LastBall = "0"
                                NewWkt = 0
                                WktIndex = 6
                        End Select
                    Case 1 To 20
                        BallResult = "Stumped out! Excellent Wicketkeeping!"
                        WktCont += 1
                        WktIndex = 5
                    Case 21
                        If Not CustomFig Then
                            NewRun = 3
                        End If
                        BallResult = GetFieldShot(True, "down") & ". Well saved and thrown. Greedy!"
                        LastBall = NewRun & "W"
                        WktIndex = 4
                    Case 22 To 40
                        BallResult = GetFieldShot(False) & ". Misunderstanding and run out!"
                        If NewRun > 0 Then
                            LastBall = NewRun & "W"
                        End If
                        WktIndex = 4
                    Case 41 To 60
                        If Not CustomFig Then
                            NewRun = 1
                        End If
                        If TempNum < 71 Then
                            BallResult = GetFieldShot(True) & ". Slow! Could have been 2. Out"
                        Else
                            BallResult = GetFieldShot(False) & ". Poor call on the 2nd. Out"
                        End If
                        LastBall = NewRun & "W"
                        WktIndex = 4
                    Case 61 To 70
                        If Not CustomFig Then
                            NewRun = 2
                        End If
                        If TempNum < 91 Then
                            BallResult = GetFieldShot(True) & ". Was never a 3! Run out"
                        Else
                            BallResult = GetFieldShot(True, "near") & ". Quick throw! Out"
                        End If
                        LastBall = NewRun & "W"
                        WktIndex = 4
                    Case 71 To 270
                        BallResult = "Given him! LBW"
                        WktIndex = 3
                        WktCont += 1
                    Case 271 To 520
                        BallResult = "Bowled him! Batsman departs"
                        WktIndex = 2
                        WktCont += 1
                    Case Else
                        WktCont += 1
                        WktIndex = 1
                        TempNum = Randomizer.Next(48)
                        Select Case TempNum
                            Case 0, 1 : BallResult = "Played straight to the bowler. Caught and bowled!"
                            Case 2 To 7 : BallResult = "Edge and gone!"
                            Case 8 To 17 : BallResult = "Edge and caught behind!"
                            Case 18 To 27 : BallResult = GetFieldShot(False, "over") & ". Easy catch!"
                            Case 28 To 37 : BallResult = GetFieldShot(False, "over") & ". Fantastic catch! Out!"
                            Case 38 To 42 : BallResult = GetFieldShot(True, "over") & ". Taken!"
                            Case Else : BallResult = GetFieldShot(True, "over") & ". Caught near the boundary!"
                        End Select
                End Select
                If FreeHit = True And WktCont > 0 Then
                    NewRun = Randomizer.Next(4)
                    NewWkt = 0
                    If NewRun = 0 Then
                        BallResult = "Out off Freehit! Lucky him!"
                        LastBall = "0"
                    Else
                        BallResult = GetFieldShot(False, "over") & ". Out on Freehit! Takes " & CStr(NewRun)
                        LastBall = CStr(NewRun)
                    End If
                End If
            Case "dot"
                TempNum = Randomizer.Next(100)
                Select Case TempNum
                    Case 0 : BallResult = "Into the block hole"
                    Case 1 : BallResult = "Sweetly timed but straight to the fielder"
                    Case 2 : BallResult = "Dangerous delivery! Could have got him"
                    Case 3 To 15 : BallResult = "Wanted a single! Sent back"
                    Case 16 To 35 : BallResult = "No run off this ball"
                    Case 36 To 50 : BallResult = "Couldn't make contact. Straight to the keeper"
                    Case 51 To 60 : BallResult = "Dot ball"
                    Case 61 To 70 : BallResult = GetFieldShot(False, "straight to")
                    Case 71 To 80 : BallResult = GetFieldShot(False, "down") & ". No runs added"
                    Case 81 To 90 : BallResult = GetFieldShot(False, "near") & ". No run"
                    Case Else : BallResult = GetFieldShot(False, "towards") & ". No runs whatsoever"
                End Select
                LastBall = "0"
            Case "n/a"
                BallResult = "We didn't expect that to happen!"
                CalcLastBall()
                If BallAs.SelectedIndex > 0 Then
                    NotBowled = True
                Else
                    NotBowled = False
                End If
        End Select
    End Sub
    Public Sub ShowResult()
        MatchSummary = t1.SelectedItem & " vs " & t2.SelectedItem & " " & t3.SelectedItem & vbNewLine & TossResult.Text & vbNewLine
        If InningNum = 1 Then
            MatchResult = "Match ABANDONED"
            AddNewComment(vbNewLine & "The match has been called off finally. Couldn't have been any worse than this." & vbNewLine)
            FirstInning = BattingTeam.Text & ": " & Score.Text & " in " & Overs.Text & " overs"
            MatchSummary = MatchSummary & FirstInning & vbNewLine & MatchResult
            WriteToHistory("Match " & (GamesInHistory + 1) & ", " & Formatter.Format(Date.Today) & vbNewLine & vbNewLine & t1.SelectedItem.ToString.ToUpper & " v " & t2.SelectedItem.ToString.ToUpper & vbNewLine & vbNewLine & t3.SelectedItem & vbNewLine & TossResult.Text & vbNewLine & vbNewLine & FirstInning & vbNewLine & vbNewLine & MatchResult)
        Else
            Select Case Tgt
                Case Is <= Runs
                    MatchResult = BattingTeam.Text & " won by " & WriteStr((10 - Wickets), "wicket")
                    Update2.Text = ""
                    Select Case ExpectedScore
                        Case Is > Tgt + 15 : AddNewComment(vbNewLine & "It was a mundane target and has been decently chased by " & BattingTeam.Text & ". No doubt that " & BowlingTeam & " fell short of runs in the first innings and hence failed to put up a competitive score. The winning team captain" & CaptainName2(BattingTeam.Text) & " said that it always motivates when you win no matter what target you are after. The captain of " & BowlingTeam & CaptainName2(BowlingTeam) & " said that they lacked the enthusiasm throughout the game and will surely learn from their mistakes." & vbNewLine)
                        Case Is < Tgt - 15 : AddNewComment(vbNewLine & "Chasing huge targets like this is never easy. But, this mammoth task looked like a child for " & BattingTeam.Text & ". It is a huge win for the team and its captain who said that high scoring games are not only a source of entertainment for the crowd but also adds to the confidence of boys. The losing captain" & CaptainName2(BowlingTeam) & " said that, " & ChrW(34) & "a score is never enough when you lose, we made some wrong decisions that costed us the game. But, it is always the road not taken to regret for." & ChrW(34) & vbNewLine)
                        Case Else : AddNewComment(vbNewLine & "Well, it was a fair game of cricket. The pitch played as expected and so did the players. But, there is always that 'extra' that differentiate ordinary and extra-ordinary efforts. A great day for " & BattingTeam.Text & " it is. The captain said that games like this are the real test of skills and his team proved better than the opponent in certain areas. The captain of " & BowlingTeam & " said that it was a tough game and also commented on the unexpected behaviour of pitch and outfield near the end of the game." & vbNewLine)
                    End Select
                Case Is > Runs + 1
                    If Balls = TotalBalls Or Wickets = "10" Then
                        MatchResult = BowlingTeam & " won by " & WriteStr((Tgt - 1 - Runs), "run")
                        Select Case ExpectedScore
                            Case Is > Tgt + 15 : AddNewComment(vbNewLine & "A score this low is rarely defended. Full credits to the bowlers of " & BowlingTeam & ". The winning captain" & CaptainName2(BowlingTeam) & " said that they have had lost the game if it was not this brilliant performance of his bowlers. The captain of " & BattingTeam.Text & " said that it was a very disappointing show from the batting department that clearly whitewashed the hardwork of bowlers. For all the emerging bowlers in the youngsters out there, this game must have inspired you all of how cricket is not just a game of batsmen." & vbNewLine)
                            Case Is < Tgt - 15 : AddNewComment(vbNewLine & "The chasing side was put in early pressure by this enormous target. However, they lost the plot somewhere in the midgame. " & BowlingTeam & " look extra-delighted by this win over " & BattingTeam.Text & ". The captain said that it's not only the first-half where his side dominated but being alive in the second half was also important. The losing captain" & CaptainName2(BattingTeam.Text) & " said that his team need to learn how to finish a game well played." & vbNewLine)
                            Case Else : AddNewComment(vbNewLine & "Sometimes, it gets difficult to play under the lights. And that might have been one of the reasons for this defeat of " & BattingTeam.Text & ". The captain of the winning side said that it is always good to be batting first in a day-night game. While the captain of the losing side" & CaptainName2(BattingTeam.Text) & " said that his team just couldn't chase the target and it was not a huge one to be accused either." & vbNewLine)
                        End Select
                    Else
                        If Balls >= TotalBalls / 3 Then
                            Dim expScore As Integer
                            expScore = GetWASPscore()
                            Select Case expScore
                                Case Is >= Tgt
                                    MatchResult = BattingTeam.Text & " won by " & WriteStr((expScore - Tgt + 1), "run") & " <D/L>"
                                    Select Case ExpectedScore
                                        Case Is > Tgt + 15 : AddNewComment(vbNewLine & "The result of the match have been calculated by Duckworth–Lewis. " & BattingTeam.Text & " has won the game by " & WriteStr((expScore - Tgt + 1), "run") & ". It was a mundane target and was being decently chased by " & BattingTeam.Text & ". No doubt that " & BowlingTeam & " fell short of runs in the first innings and hence failed to put up a competitive score. The winning team captain" & CaptainName2(BattingTeam.Text) & " said that it always motivates when you win no matter what target you are after. The captain of " & BowlingTeam & CaptainName2(BowlingTeam) & " said that they lacked the enthusiasm throughout the game and will surely learn from their mistakes." & vbNewLine)
                                        Case Is < Tgt - 15 : AddNewComment(vbNewLine & "No worries! At least we got a result. " & BattingTeam.Text & " has won the game by " & WriteStr((expScore - Tgt + 1), "run") & " calculated by D/L method. Chasing huge targets like this is never easy. But, maintaining a good runrate and keeping wickets in hand proved to be the key for " & BattingTeam.Text & ". It is a huge win for the team and its captain who said that high scoring games are not only a source of entertainment for the crowd but also adds to the confidence of boys. The losing captain" & CaptainName2(BowlingTeam) & " said that, " & ChrW(34) & "a score is never enough when you lose, we made some wrong decisions that costed us the game. But, it is always the road not taken to regret for. I also dislike the way statistics is into cricket, because you never know what the result could have been." & ChrW(34) & vbNewLine)
                                        Case Else : AddNewComment(vbNewLine & "The spoilsport could not stop the result anyways. " & BattingTeam.Text & " has won the game by " & WriteStr((expScore - Tgt + 1), "run") & " by D/L method. Well, it was a fair game of cricket. The pitch played as expected and so did the players. But, there is always that 'extra' that differentiate ordinary and extra-ordinary efforts. A great day for " & BattingTeam.Text & " it is. The captain said that games like this are the real test of skills and his team proved better than the opponent in certain areas. The captain of " & BowlingTeam & " said that it was a tough game and also commented on the usage of D/L method to find results." & vbNewLine)
                                    End Select
                                Case Is < Tgt - 1
                                    MatchResult = BowlingTeam & " won by " & WriteStr((Tgt - 1 - expScore), "run") & "<D/L>"
                                    Select Case ExpectedScore
                                        Case Is > Tgt + 15 : AddNewComment(vbNewLine & "The result of the match have been calculated by Duckworth–Lewis. " & BattingTeam.Text & " has won the game by " & WriteStr((expScore - Tgt + 1), "run") & ". A score this low is rarely defended. Full credits to the bowlers of " & BowlingTeam & ". The winning captain" & CaptainName2(BowlingTeam) & " said that they have had lost the game if it was not this brilliant performance of his bowlers. The captain of " & BattingTeam.Text & " said that it was a very disappointing show from the batting department that clearly whitewashed the hardwork of bowlers. Everytime we see a result calculated by D/L, we sense the buzz of debate going on over it. Well, we never know who is it going to favor, because ironically it is unbiased." & vbNewLine)
                                        Case Is < Tgt - 15 : AddNewComment(vbNewLine & "No worries! At least we got a result. " & BattingTeam.Text & " has won the game by " & WriteStr((expScore - Tgt + 1), "run") & " calculated by D/L method. The chasing side was put in early pressure by this enormous target. However, they lost the plot somewhere in the midgame. " & BowlingTeam & " look extra-delighted by this win over " & BattingTeam.Text & ". The captain said that it's not only the first-half where his side dominated but being alive in the second half was also important. The losing captain" & CaptainName2(BattingTeam.Text) & " said that his team need to learn how to finish a game well played. He also made a short comment on D/L method saying that, " & ChrW(34) & "it's their job. Our job is to play well and we definitely failed tonight in doing so." & ChrW(34) & vbNewLine)
                                        Case Else : AddNewComment(vbNewLine & "The spoilsport could not stop the result anyways. " & BattingTeam.Text & " has won the game by " & WriteStr((expScore - Tgt + 1), "run") & " by D/L method. Sometimes, it gets difficult to play under the lights. And that might have been one of the reasons for this defeat of " & BattingTeam.Text & ". The captain of the winning side said that it is always good to be batting first in a day-night game. While the captain of the losing side" & CaptainName2(BattingTeam.Text) & " said that his team just couldn't chase the target and it was not a huge one to be accused either. He also said that he stopped whining over D/L method because it is a fair system. Someday, it favors you and it kills you some other day." & vbNewLine)
                                    End Select
                                Case Else
                                    MatchResult = "Match TIED <D/L>"
                                    AddNewComment(vbNewLine & "On paper it a game of tie, but we know what the result was going to be. That is why, D/L method is still a topic of debate among professionals." & vbNewLine)
                            End Select
                        Else
                            MatchResult = "Match ABANDONED"
                            AddNewComment(vbNewLine & "So, the news is that the match has been abandoned. A waste of effort for both the teams." & vbNewLine)
                        End If
                    End If
                Case Else
                    MatchResult = "Match TIED"
                    AddNewComment(vbNewLine & "Wow! It was a great breathtaking game of cricket. What a comeback we just witnessed but they just couldn't convert it into any satisfactory result. Both the teams deserved to win the match but it probably had to be a game in history." & vbNewLine)
                    Update2.Text = ""
            End Select
            MatchSummary = MatchSummary & FirstInning & vbNewLine & BattingTeam.Text & ": " & Score.Text & " in " & Overs.Text & " overs" & vbNewLine & MatchResult
            WriteToHistory("Match " & (GamesInHistory + 1) & ", " & Formatter.Format(Date.Today) & vbNewLine & vbNewLine & t1.SelectedItem.ToString.ToUpper & " v " & t2.SelectedItem.ToString.ToUpper & vbNewLine & vbNewLine & t3.SelectedItem & vbNewLine & TossResult.Text & vbNewLine & vbNewLine & FirstInning & vbNewLine & BattingTeam.Text & ": " & Score.Text & " in " & Overs.Text & " overs" & vbNewLine & vbNewLine & MatchResult)
        End If
        btnAction.Content = MatchResult & ". Show Summary"
        tgbCustom.IsEnabled = False
        PlayRandX.Visibility = Windows.UI.Xaml.Visibility.Collapsed
    End Sub
    Public Sub WriteToHistory(HistoryStr As String)
        GamesInHistory += 1
        RoamSet.Values("GamesInHistory") = GamesInHistory
        TempStr = "History" & GamesInHistory
        If GamesInHistory = 1 Then
            RoamSet.Values(TempStr) = HistoryStr
            HistoryCS = HistoryStr
        Else
            RoamSet.Values(TempStr) = HistoryStr & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & RoamSet.Values(TempStr)
            HistoryCS = HistoryStr & vbNewLine & "___________________________________________________" & vbNewLine & vbNewLine & HistoryCS
        End If
        If tgbHistory.IsChecked = True Then
            txtRight.Text = HistoryCS
        End If
    End Sub
    Public Function CaptainName(TeamName As String) As String
        Select Case TeamName
            Case "England" : CaptainName = "Alastair Cook"
            Case "South Africa" : CaptainName = "AB de Villiers"
            Case "Sri Lanka" : CaptainName = "Mahela Jayawardene"
            Case "India" : CaptainName = "MS Dhoni"
            Case "Australia" : CaptainName = "Michael Clarke"
            Case "Pakistan" : CaptainName = "Misbah-ul-Haq"
            Case "West Indies" : CaptainName = "Darren Sammy"
            Case "New Zealand" : CaptainName = "Ross Taylor"
            Case "Bangladesh" : CaptainName = "Mushfiqur Rahim"
            Case "Zimbabwe" : CaptainName = "Brendan Taylor"
            Case "Ireland" : CaptainName = "William Porterfield"
            Case "Netherlands" : CaptainName = "Peter Borren"
            Case "Kenya" : CaptainName = "Collins Obuya"
            Case "Afghanistan" : CaptainName = "Nowroz Mangal"
            Case "Scotland" : CaptainName = "Gordon Drummond"
            Case "Canada" : CaptainName = "Rizwan Cheema"
            Case "Argentina" : CaptainName = "Esteban Macdermott"
            Case "Belgium" : CaptainName = "Simon Newport"
            Case "Bermuda" : CaptainName = "David Hemp"
            Case "Botswana" : CaptainName = "Harry Flemming"
            Case "Cayman Islands" : CaptainName = "Ryan Bovell"
            Case "Denmark" : CaptainName = "Michael Pedersen"
            Case "Fiji" : CaptainName = "Josefa Rika"
            Case "France" : CaptainName = "David Bordes"
            Case "Germany" : CaptainName = "Asif Khan"
            Case "Gubraltar" : CaptainName = "Iain Latin"
            Case "Guernsey" : CaptainName = "Stuart Le Prevost"
            Case "Honk Kong" : CaptainName = "Najeeb Amar"
            Case "Israel" : CaptainName = "Herschel Gutman"
            Case "Italy" : CaptainName = "Alessandro Bonora"
            Case "Japan" : CaptainName = "Tatsuro Chino"
            Case "Jersey" : CaptainName = "Ryan Driver"
            Case "Kuwait" : CaptainName = "Sanal Govind"
            Case "Malaysia" : CaptainName = "Suresh Navaratnam"
            Case "Namibia" : CaptainName = "Sarel Burger"
            Case "Nepal" : CaptainName = "Paras Khadka"
            Case "Netherlands" : CaptainName = "Peter Borren"
            Case "Nigeria" : CaptainName = "Endurance Ofem"
            Case "Papua New Guinea" : CaptainName = "Rarua Dikana"
            Case "Singapore" : CaptainName = "Chetan Suryawanshi"
            Case "Suriname" : CaptainName = "Shazam Ramjohn"
            Case "Tanzania" : CaptainName = "Hamisi Abdallah"
            Case "Thailand" : CaptainName = "Zeeshan Khan"
            Case "Uganda" : CaptainName = "Joel Olwenyi"
            Case "United Arab Emirates" : CaptainName = "Arshad Ali"
            Case "United States" : CaptainName = "Sushil Nadkarni"
            Case "Vanuatu" : CaptainName = "Andrew Mansale"
            Case "Zambia" : CaptainName = "Safraz Patel"
            Case "Austria" : CaptainName = "Timothy Simpson"
            Case "Bahamas" : CaptainName = "Gregory Taylor"
            Case "Bahrain" : CaptainName = "Yasir Sadeq"
            Case "Belize" : CaptainName = "Dirk Sutherland"
            Case "Bhutan" : CaptainName = "Damber Gurung"
            Case "Brazil" : CaptainName = "Greigor Caisley"
            Case "Brunei" : CaptainName = "Sujaya Kamat"
            Case "Bulgaria" : CaptainName = "Saif–ur-Rehman"
            Case "Chile" : CaptainName = "Simon Shalders"
            Case "China" : CaptainName = "Wang Lei"
            Case "Cook Islands" : CaptainName = "Teunu Eliaba"
            Case "Costa Rica" : CaptainName = "Julian Olivier"
            Case "Croatia" : CaptainName = "John Vujnovich"
            Case "Cyprus" : CaptainName = "Michael Kyriacou"
            Case "Czech Republic" : CaptainName = "Craig Hampson"
            Case "Estonia" : CaptainName = "Timothy Heath"
            Case "Falkland" : CaptainName = "Elliott Taylforth"
            Case "Finland" : CaptainName = "Jonathan Scamans"
            Case "Gambia" : CaptainName = "Prince Johnson"
            Case "Ghana" : CaptainName = "Peter Ananya"
            Case "Greece" : CaptainName = "Nic Pothas"
            Case "Hungary" : CaptainName = "Andrew Leckonby"
            Case "Indonesia" : CaptainName = "I Kadek Putra Dharmwan"
            Case "Iran" : CaptainName = "Yousef Raeisi"
            Case "Isle of Man" : CaptainName = "Mark Young"
            Case "Lesotho" : CaptainName = "Motsielao Nonyane"
            Case "Luxembourg" : CaptainName = "Tony Whiteman"
            Case "Malawi" : CaptainName = "Zafarullah Sukhera"
            Case "Maldives" : CaptainName = "Moosa Kaleem"
            Case "Malta" : CaptainName = "Michael Caruana"
            Case "Mexico" : CaptainName = "Tushar Gupta"
            Case "Morocco" : CaptainName = "Salah El Mouridi"
            Case "Mozambique" : CaptainName = "Bineesh Vadavathy"
            Case "Myanmar" : CaptainName = "Ye Myo Tun"
            Case "Norway" : CaptainName = "Damien Shortis"
            Case "Oman" : CaptainName = "Hemal Mehta"
            Case "Panama" : CaptainName = "Irfan Tarajia"
            Case "Peru" : CaptainName = "Miles Buesst"
            Case "Portugal" : CaptainName = "Akbar Saiyad"
            Case "Qatar" : CaptainName = "Umer Taj"
            Case "Russia" : CaptainName = "Ashwani Chopra"
            Case "Rwanda" : CaptainName = "Mohammed Jashat"
            Case "Samoa" : CaptainName = "Geoff Clarke"
            Case "Saudi Arabia" : CaptainName = "Shoaib Ali"
            Case "Seychelles" : CaptainName = "Kaushal Patel"
            Case "Sierra Leone" : CaptainName = "Lansana Lamin"
            Case "Slovenia" : CaptainName = "Mark Oman"
            Case "South Korea" : CaptainName = "Joohun Choi"
            Case "Spain" : CaptainName = "Mark Spencer"
            Case "Sweden" : CaptainName = "Adnan Raza"
            Case "Tonga" : CaptainName = "Aiveni Taakimoeaka"
            Case "Turkey" : CaptainName = "Jonathan Clarkson"
            Case "Turks and Caicos Islands" : CaptainName = "W Williams"
            Case "Switzerland" : CaptainName = "Raja Hafeez"
            Case "Belarus" : CaptainName = "Kaushal Tiwari"
            Case "El Salvador" : CaptainName = "Philip Mostyn"
            Case "Latvia" : CaptainName = "Sumit Chakravarty"
            Case "Lithuania" : CaptainName = "Zayne Nair"
            Case "Macedonia" : CaptainName = "Chenna Reddy"
            Case "Mauritius" : CaptainName = "Ashwini Sood"
            Case "Serbia" : CaptainName = "Vladimir Ninković"
            Case "Slovakia" : CaptainName = "Vladimir Chudacik"
            Case Else : CaptainName = "the captain"
        End Select
    End Function
    Public Function CaptainName2(TeamName As String) As String
        If CaptainName(TeamName) = "the captain" Then
            CaptainName2 = ""
        Else
            CaptainName2 = ", " & CaptainName(TeamName)
        End If
    End Function
    Public Function GetFieldShot(Outside15 As Boolean, Optional ShotType As String = "") As String
        If ShotType = "" Then
            TempNum = Randomizer.Next(10)
            Select Case TempNum
                Case 0 : ShotType = "over"
                Case 1 To 3 : ShotType = "down"
                Case 4 To 6 : ShotType = "towards"
                Case Else : ShotType = "near"
            End Select
        End If
        TempNum = Randomizer.Next(30)
        If Outside15 Then
            Select Case TempNum
                Case 0 : GetFieldShot = "the bowler"
                Case 1 To 4 : GetFieldShot = "long off"
                Case 5 To 7 : GetFieldShot = "deep backward"
                Case 8 To 9 : GetFieldShot = "deep cover point"
                Case 10 To 11 : GetFieldShot = "deep extra cover"
                Case 12 To 13 : GetFieldShot = "deep cover"
                Case 14 : GetFieldShot = "square"
                Case 15 : GetFieldShot = "the third man"
                Case 16 : GetFieldShot = "fine leg"
                Case 17 To 19 : GetFieldShot = "deep forward"
                Case 20 To 22 : GetFieldShot = "deep mid-wicket"
                Case 23 To 25 : GetFieldShot = "deep square leg"
                Case Else : GetFieldShot = "long on"
            End Select
        Else
            Select Case TempNum
                Case 0 : GetFieldShot = "gully"
                Case 1 : GetFieldShot = "slip"
                Case 2 : GetFieldShot = "backward short leg"
                Case 3 To 5 : GetFieldShot = "point"
                Case 6 To 8 : GetFieldShot = "cover"
                Case 9 To 14 : GetFieldShot = "mid-off"
                Case 15 To 18 : GetFieldShot = "the bowler"
                Case 19 To 23 : GetFieldShot = "mid-on"
                Case 24 To 26 : GetFieldShot = "square leg"
                Case Else : GetFieldShot = "mid-wicket"
            End Select
        End If
        If ShotType = "over" Then
            If Outside15 Then
                GetFieldShot = "Lofted over " & GetFieldShot
            Else
                TempNum = Randomizer.Next(3)
                Select Case TempNum
                    Case 0 : GetFieldShot = "Takes arial route"
                    Case 1 : GetFieldShot = "In the air"
                    Case Else : GetFieldShot = "Top edge! towards " & GetFieldShot
                End Select
            End If
        Else
            TempNum = Randomizer.Next(4)
            Select Case TempNum
                Case 0 : GetFieldShot = "Played " & ShotType & " " & GetFieldShot
                Case 1 : GetFieldShot = "Nice shot " & ShotType & " " & GetFieldShot
                Case 2 : GetFieldShot = "Worked " & ShotType & " " & GetFieldShot
                Case Else : GetFieldShot = "Ball is moving " & ShotType & " " & GetFieldShot
            End Select
        End If
    End Function
    Public Function WriteStr(forNumber As Double, withString As String) As String
        If forNumber = 1 Then
            WriteStr = forNumber & " " & withString
        Else
            WriteStr = forNumber & " " & withString & "s"
        End If
    End Function

    Public Sub btnActionCmds()
        If btnAction.IsEnabled Then
            If btnAction.Content = "Next Inning" Then
                If TossW = BattingTeam.Text Then
                    BattingTeam.Text = TossL
                    BowlingTeam = TossW
                Else
                    BattingTeam.Text = TossW
                    BowlingTeam = TossL
                End If
                InningNum += 1
                Tgt = Runs + 1
                Tgt1 = 5 * Tgt / 4
                Tgt2 = 3 * Tgt / 4
                RunsBeforeOver = 0
                WicketsBeforeOver = 0
                RequiredRate = Tgt * 6 / TotalBalls
                Runs = 0
                Wickets = 0
                Balls = 0
                WASPscore = GetWASPscore()
                Dim WASPpercent As Integer
                If WASPscore > Tgt1 Then
                    WASPpercent = Math.Round(75 + (WASPscore - Tgt) * (Balls / TotalBalls), 0)
                ElseIf WASPscore < Tgt2 Then
                    WASPpercent = Math.Round(25 + (WASPscore - Tgt) * (Balls / TotalBalls), 0)
                ElseIf Runs >= Tgt Then
                    WASPpercent = 100
                Else
                    WASPpercent = Math.Round(50 + (WASPscore - Tgt) * 10 * (Balls / TotalBalls), 0)
                End If
                If WASPpercent > 100 Then
                    WASP.Text = "100"
                ElseIf WASPpercent < 0 Then
                    WASP.Text = "0"
                Else
                    WASP.Text = WASPpercent
                End If
                WASP.Text = WASP.Text & "% (Tgt " & Tgt & ")"
                WktCont = 0
                WktCont2 = 0
                Score.Text = "0/0"
                Overs.Text = "0"
                RunRate.Text = "0"
                Extras.Text = "0"
                LastBall = ""
                ThisOverBar.Text = ""
                btnAction.Content = "Play Random"
                tgbCustom.IsEnabled = True
                PlayRandX.Visibility = Windows.UI.Xaml.Visibility.Visible
                Update2.Text = BattingTeam.Text & " need " & WriteStr(Tgt, "run") & " in " & TotalBalls & " balls at " & WriteStr(Math.Round(Tgt * 6 / TotalBalls, 2), "run") & " per over"
                Select Case TypeofPitch
                    Case 3 : Update1.Text = "All Set. Great batting conditions"
                    Case 4 : Update1.Text = "Up for chase. There is no devil in the pitch"
                    Case 5 : Update1.Text = "Bowlers are delighted. Pitch has played her part"
                End Select
            ElseIf btnAction.Content = "Play Random" Then
                NewRun = 0
                NewWkt = 0
                NewExt = 0
                Uncertainty = Randomizer.Next(10000)
                If Uncertainty = 4102 Then
                    Update2.Text = "It has started raining. Match stopped due to heavy rain."
                    AddNewComment(vbNewLine & "Well well well! It has started raining heavily and the covers has been brought. The match cannot progress, says the field umpires. The crowd must be cursing their gods for the spoilsport hence caused." & vbNewLine)
                    ShowResult()
                    Exit Sub
                ElseIf Uncertainty = 1670 Then
                    Update2.Text = "Insufficient light. Match stopped due to bad lights."
                    AddNewComment(vbNewLine & "The players have been complaining since long that they are unable to see the ball because of bad lights. Now, the umpires have declared that the match has to be stopped. The crowd is angry about the cricket ground management. Well, it looks like a day wasted now." & vbNewLine)
                    ShowResult()
                    Exit Sub
                End If
                If Balls Mod 6 = 0 And ThisOverBar.Text <> "" Then
                    If ThisOverBar.Text.Length > 11 Then
                        ThisOverBar.Text = ""
                    End If
                End If
                If ThisOverBar.Text.Length > 20 Then
                    ThisOverBar.Text = ""
                End If
                RandomResult()
                Do While BallResult = Update1.Text
                    RandomResult()
                Loop
                If InningNum = 2 Then
                    Do
                        If (NewRun + Runs > Tgt And NewRun < 4) Or (NewRun + Runs >= Tgt And NewRun < 4 And NewWkt = 1) Then
                            RandomResult()
                        Else
                            Exit Do
                        End If
                    Loop
                End If
                PostBall()
            Else
                Update2.Text = MatchSummary
                btnAction.IsEnabled = False
                btnStart.Focus(Windows.UI.Xaml.FocusState.Pointer)
            End If
        End If
    End Sub
    Public Sub RandomResult(Optional WithoutComment As Boolean = False)
        CalculateChances(True)
        Select Case Randomizer.Next(1000)
            Case WideChanceFrom To WideChanceTo : BallResult = "wd"
            Case NoBallChanceFrom To NoBallChanceTo : BallResult = "nb"
            Case ByeChanceFrom : BallResult = "b"
            Case Wide4ChanceFrom To Wide4ChanceTo : BallResult = "4wd"
            Case FiveChanceFrom : BallResult = "5"
            Case DeadBallChanceFrom To DeadBallChanceTo : BallResult = "db"
            Case AppealChanceFrom To AppealChanceTo : BallResult = "a/f"
            Case ThreeChanceFrom To ThreeChanceTo : BallResult = "3"
            Case SingleChanceFrom To SingleChanceTo : BallResult = "1"
            Case DoubleChanceFrom To DoubleChanceTo : BallResult = "2"
            Case FourChanceFrom To FourChanceTo : BallResult = "4"
            Case SixChanceFrom To SixChanceTo : BallResult = "6"
            Case WicketChanceFrom To WicketChanceTo : BallResult = "W"
            Case Else : BallResult = "dot"
        End Select
        If BallResult <> "W" Then
            WktIndex = 0
        End If
        If Not WithoutComment Then
            RandomCommentary(BallResult)
        End If
    End Sub

    Public Sub CalculateChances(Optional CalledByRes As Boolean = False, Optional BatsmanAverage As Integer = 0, Optional BowlerAverage As Integer = 0, Optional BatsmanStrikeRate As Integer = 0, Optional BowlerEconomy As Integer = 0)
        If BatsmanAverage = 0 Then
            BatsmanAverage = (25 + ((TotalBalls - 60) / 10)) * ((4 - (Wickets / 3)) / 4)
        End If
        If BowlerAverage = 0 Then
            BowlerAverage = 35 - ((300 - TotalBalls) / 15)
        End If
        If BatsmanStrikeRate = 0 Then
            BatsmanStrikeRate = 80 + ((300 - TotalBalls) / 3)
        End If
        If BowlerEconomy = 0 Then
            BowlerEconomy = (6 / 100) * (80 + ((300 - TotalBalls) / 3))
        End If
        'Chance means n times per 1000 balls
        BatsmanOutChance = (10 * BatsmanStrikeRate) / BatsmanAverage  'Solving 1000 / (BatsmanAverage * (100 / BatsmanStrikeRate))
        BowlerStrikeRate = (BowlerEconomy * 50) / 3 'Solving (BowlerEconomy * 100) / 6
        BowlerOutChance = (10 * BowlerStrikeRate) / BowlerAverage 'Solving 1000 / (BowlerAverage * (100 / BowlerStrikeRate))
        If RequiredRate > 18 Then
            RequiredRate = 18
        ElseIf RequiredRate < 0.5 * RunRate.Text And InningNum = 2 Then
            RequiredRate *= 1.5
        End If
        Dim TotalRuns As Integer = ((BatsmanStrikeRate + BowlerStrikeRate) * RequiredRate * 1000) / (12 * (80 + ((300 - TotalBalls) / 3)))
        Dim PercentRunsBoundaries As Integer = 34 + ((RequiredRate) * 3)
        PercentRuns6 = PercentRunsBoundaries * (RequiredRate / 38)
        PercentRuns4 = PercentRunsBoundaries - PercentRuns6
        PercentRuns3 = 3
        PercentRunsExtra = 2
        PercentRuns2 = (100 - (PercentRunsExtra + PercentRuns3 + PercentRuns4 + PercentRuns6)) / 3
        PercentRuns1 = 100 - (PercentRunsExtra + PercentRuns3 + PercentRuns4 + PercentRuns6 + PercentRuns2)
        FourChance = (PercentRuns4 * TotalRuns) / 400
        SixChance = (PercentRuns6 * TotalRuns) / 600
        ThreeChance = (PercentRuns3 * TotalRuns) / 300
        DoubleChance = (PercentRuns2 * TotalRuns) / 200
        ExtraChance = (PercentRunsExtra * TotalRuns) / 100
        SingleChance = (PercentRuns1 * TotalRuns) / 100
        Dim RemChances As Integer = 1000 - (FourChance + SixChance + ThreeChance + DoubleChance + ExtraChance + SingleChance)
        WicketChance = ((BatsmanOutChance + BowlerOutChance) / 40) * ((((RequiredRate / 3) + ((TypeofPitch * 9) / 10)) ^ 2) / 2)
        DotChance = (160 / (BatsmanStrikeRate + BowlerStrikeRate)) * (500 + 80 * (((TypeofPitch * 9) / 10) - (2 * (RequiredRate / 3))))

        If FreeHit And CalledByRes Then
            SixChance *= 4
            FourChance *= 3
            WicketChance /= 20
        End If

        WideChanceFrom = 0
        WideChanceTo = (ExtraChance * (3 / 5))
        NoBallChanceFrom = (ExtraChance * (3 / 5)) + 1
        NoBallChanceTo = (ExtraChance * (3 / 5)) + 2
        ByeChanceFrom = (ExtraChance * (3 / 5)) + 3
        ' ByeChanceTo 
        Wide4ChanceFrom = (ExtraChance * (3 / 5)) + 4
        Wide4ChanceTo = (ExtraChance * (3 / 5)) + 5
        FiveChanceFrom = (ExtraChance * (3 / 5)) + 6
        ' FiveChanceTo 
        DeadBallChanceFrom = (ExtraChance * (3 / 5)) + 7
        DeadBallChanceTo = ExtraChance - 1
        AppealChanceFrom = ExtraChance
        AppealChanceTo = ExtraChance + 28
        ThreeChanceFrom = ExtraChance + 29
        ThreeChanceTo = ExtraChance + 28 + ThreeChance
        SingleChanceFrom = ExtraChance + 29 + ThreeChance
        SingleChanceTo = ExtraChance + 28 + ThreeChance + SingleChance
        DoubleChanceFrom = ExtraChance + 29 + ThreeChance + SingleChance
        DoubleChanceTo = ExtraChance + 28 + ThreeChance + SingleChance + DoubleChance
        FourChanceFrom = ExtraChance + 29 + ThreeChance + SingleChance + DoubleChance
        FourChanceTo = ExtraChance + 28 + ThreeChance + SingleChance + DoubleChance + FourChance
        SixChanceFrom = ExtraChance + 29 + ThreeChance + SingleChance + DoubleChance + FourChance
        SixChanceTo = ExtraChance + 28 + ThreeChance + SingleChance + DoubleChance + FourChance + SixChance
        WicketChanceFrom = ExtraChance + 29 + ThreeChance + SingleChance + DoubleChance + FourChance + SixChance
        WicketChanceTo = ExtraChance + 28 + ThreeChance + SingleChance + DoubleChance + FourChance + SixChance + WicketChance
    End Sub

    Public Function GetWASPscore() As Integer
        CalculateChances()
        RemBalls = TotalBalls - Balls
        If (WicketChance * RemBalls) / 1000 > 10 - Wickets Then
            RemBalls = ((10 - Wickets) * 1000) / WicketChance
        End If
        GetWASPscore = Runs + (((SingleChance + ExtraChance) + (2 * DoubleChance) + (3 * ThreeChance) + (4 * FourChance) + (6 * SixChance)) * (RemBalls / 1000))
    End Function
    '#End Region
End Class