// Copyright 1998, 1999, 2000, 2001, 2002, 2003, 2004 � Erik van der Neut - All rights reserved.
if(document)
   {
   var args=b27();
   var a08=new Array("E","A","D","G","B","E");
   var a07=new Array("EADGBE|EADGBE - �����������","DADGBE|DADGBE - Drop-D","DADGBD|DADGBD - Double drop-D","DADF#AD|DADF#AD - �������� D",
                     "DADFAD|DADFAD - �������� D �����","DADGAD|DADGAD - DADGAD","DADDAD|DADDAD - D modal","EADGCF|EADGCF - ���������",
                     "EBEG#BE|EBEAbBE - �������� E","DGDGBE|DGDGBE - G6","DGDGBD|DGDGBD - �������� G","DGDGA#D|DGDGBbD - G �����",
                     "EAEAC#E|EAEAC#E - �������� A","EAEACE|EAEACE - A �����","CGCGAE|CGCGAE - C6","CGCGCE|CGCGCE - �������� C",
                     "CGDGAD|CGDGAD - ������ C","Custom|������������");
   var tuneup_off=new Image();
   tuneup_off.src="tuneup_off.gif";
   var tuneup_on=new Image();
   tuneup_on.src="tuneup_on.gif";
   var tunedown_off=new Image();
   tunedown_off.src="tunedown_off.gif";
   var tunedown_on=new Image();
   tunedown_on.src="tunedown_on.gif";
   hC=new Image();hC.src="hC.gif";
   hCis=new Image();
   hCis.src="hCis.gif";
   hDb=new Image();
   hDb.src="hDb.gif";
   hD=new Image();
   hD.src="hD.gif";
   hDis=new Image();
   hDis.src="hDis.gif";
   hEb=new Image();
   hEb.src="hEb.gif";
   hE=new Image();
   hE.src="hE.gif";
   hF=new Image();
   hF.src="hF.gif";
   hFis=new Image();
   hFis.src="hFis.gif";
   hGb=new Image();
   hGb.src="hGb.gif";
   hG=new Image();
   hG.src="hG.gif";
   hGis=new Image();
   hGis.src="hGis.gif";
   hAb=new Image();
   hAb.src="hAb.gif";
   hA=new Image();
   hA.src="hA.gif";
   hAis=new Image();
   hAis.src="hAis.gif";
   hBb=new Image();
   hBb.src="hBb.gif";
   hB=new Image();
   hB.src="hB.gif";
   h=new Image();
   h.src="h.gif";
   s_thick=new Image();
   s_thick.src="s_thick.gif";
   s_thin=new Image();
   s_thin.src="s_thin.gif";
   s_thin_=new Image();
   s_thin_.src="s_thin_.gif";
   hilite=new Image();
   hilite.src="hilite.gif";
   sp=new Image();
   sp.src="sp.gif";
   so_=new Image();
   so_.src="so_.gif";
   
   var intervalNoToName=new Array("","1","b2","2","b3","3","4","b5","5","is5","6","b7","7","R","b2","2","b3","3","4","b5","5","#5","6");
   var b15=new Array();
   b15["R"]=1;b15["1"]=1;b15["b2"]=2;b15["2"]=3;b15["#2"]=4;b15["b3"]=4;b15["3"]=5;b15["4"]=6;b15["#4"]=7;b15["b5"]=7;b15["5"]=8;b15["#5"]=9;b15["b6"]=9;b15["6"]=10;b15["bb7"]=10;b15["#6"]=11;b15["b7"]=11;b15["7"]=12;b15["8"]=1;b15["b9"]=2;b15["9"]=3;b15["#9"]=4;b15["10"]=5;b15["11"]=6;b15["#11"]=7;b15["12"]=8;b15["b13"]=9;b15["13"]=10;
   var intervalNoToNote_C=new Array("","C","Cis","D","Dis","E","F","Fis","G","Gis","A","Ais","B","C");
   var intervalNoToNote_Cis=new Array("","Cis","D","Dis","E","F","Fis","G","Gis","A","Ais","B","C","Cis");
   var intervalNoToNote_D=new Array("","D","Dis","E","F","Fis","G","Gis","A","Ais","B","C","Cis","D");
   var intervalNoToNote_Dis=new Array("","Dis","E","F","Fis","G","Gis","A","Ais","B","C","Cis","D","Dis");
   var intervalNoToNote_E=new Array("","E","F","Fis","G","Gis","A","Ais","B","C","Cis","D","Dis","E");
   var intervalNoToNote_F=new Array("","F","Fis","G","Gis","A","Ais","B","C","Cis","D","Dis","E","F");
   var intervalNoToNote_Fis=new Array("","Fis","G","Gis","A","Ais","B","C","Cis","D","Dis","E","F","Fis");
   var intervalNoToNote_G=new Array("","G","Gis","A","Ais","B","C","Cis","D","Dis","E","F","Fis","G");
   var intervalNoToNote_Gis=new Array("","Gis","A","Ais","B","C","Cis","D","Dis","E","F","Fis","G","Gis");
   var intervalNoToNote_A=new Array("","A","Ais","B","C","Cis","D","Dis","E","F","Fis","G","Gis","A");
   var intervalNoToNote_Ais=new Array("","Ais","B","C","Cis","D","Dis","E","F","Fis","G","Gis","A","Ais");
   var intervalNoToNote_B=new Array("","B","C","Cis","D","Dis","E","F","Fis","G","Gis","A","Ais","B");
   var a94=new Array();
   a94["C"]=1;a94["Cis"]=2;a94["Db"]=2;a94["D"]=3;a94["Dis"]=4;a94["Eb"]=4;a94["E"]=5;a94["F"]=6;a94["Fis"]=7;a94["Gb"]=7;a94["G"]=8;a94["Gis"]=9;a94["Ab"]=9;a94["A"]=10;a94["Ais"]=11;a94["Bb"]=11;a94["B"]=12;
   var c38=new Array("C","C#","Db","D","E","F","F#","Gb","G","G#","Ab","A","A#","Bb","B");
   c38["C"]=new Array("C","D","E","F","G","A","B");c38["Cis"]=new Array("C#","D#","E#","F#","G#","A#","B#");
   c38["Db"]=new Array("Db","Eb","F","Gb","Ab","Bb","C");
   c38["D"]=new Array("D","E","F#","G","A","B","C#");
   c38["Dis"]=new Array("D#","E#","F##","G#","A#","B#","C##");
   c38["Eb"]=new Array("Eb","F","G","Ab","Bb","C","D");
   c38["E"]=new Array("E","F#","G#","A","B","C#","D#");
   c38["F"]=new Array("F","G","A","Bb","C","D","E");
   c38["Fis"]=new Array("F#","G#","A#","B","C#","D#","E#");
   c38["Gb"]=new Array("Gb","Ab","Bb","Cb","Db","Eb","F");
   c38["G"]=new Array("G","A","B","C","D","E","F#");
   c38["Gis"]=new Array("G#","A#","B#","C#","D#","E#","F##");
   c38["Ab"]=new Array("Ab","Bb","C","Db","Eb","F","G");
   c38["A"]=new Array("A","B","C#","D","E","F#","G#");
   c38["Ais"]=new Array("A#","B#","C##","D#","E#","F##","G##");
   c38["Bb"]=new Array("Bb","C","D","Eb","F","G","A");
   c38["B"]=new Array("B","C#","D#","E","F#","G#","A#");
   var b19="Chord";
   var c10=0;
   var c11=1;
   var Chords=new Array();
   var a81=0;
   var b63=new Array();
   var a73=new Array();
   var a80=0;
   var a74=new Array();
   var c08=new Array();
   var c09=new Array();
   var c36=new Array();
   var c35=new Array();
   var c34=new Array();
   var c37=new Array();
   for ( var i=1; i < 13; i++ ) c36[i]=0;
   for ( var i=1; i < 13; i++ ) c35[i]=0;
   for ( var i=1; i < 13; i++ ) c34[i]=0;
   for ( var i=1; i < 13; i++ ) c37[i]=0;
   var c41="";
   var a25="";
   var fb_player="R";
   if ( args.plyr ) fb_player = args.plyr;
   var fb_bass = "bottom";
   if ( args.bass ) fb_bass=args.bass;
   var displayNames = "in";
   var c13="STRICT";
   var root_disambig_sharp_or_flat="#";
   
   a79();
   a76();
   
   var NS = ( window.Event ) ? 1:0; 
   if ( NS ) document.captureEvents( Event.KEYPRESS );
   document.onkeypress=c46;
}

function c46(e)
{
   var code = (NS) ? e.which : event.keyCode;
   var key = String.fromCharCode( code );

   if ( key == '�' || key == '�' ) togglePlayingHand();
   if ( key == '�' || key == '�' ) toggleBassStrings();
   if ( key == '�' || key == '�' ) toggleInNn();
   if ( key == '�' || key == '�' ) toggleSpelling();
   if ( key == '�' || key == '�' ) toggleSharpFlat();
}

function buildit()
{
   var a06=0;
   
   b69(a06);
   b79(a06);
   b81(a06);
   
   setVariablesFromArgs();
   setRadioButtons();
   FirstChord();
}

function FirstChord()
{
   document.aspnetForm.chordRoot[0].selected=true;
   document.aspnetForm.chordName[0].selected=true;
   showFingerSetting("Chords");
}

function a79()
{
   chord("Major","R Major","<R>, <R>Maj, <R>M","1,3,5");
   chord("","R5","<R> power chord","1,5");
   chord("Major","R-5","<R>(b5), <R> flattened 5th","1,3,b5");
   chord("Major","R6","<R>Maj6, <R>M6","1,3,5,6");
   chord("Major","R6/9","<R>6add9, <R>6(add9), <R>Maj6(add9), <R>M6(add9)","1,3,(5),6,9");
   chord("Major","R7","<R> Dominant 7","1,3,(5),b7");
   chord("Major","Radd9","<R> added 9","1,3,5,9");
   chord("Major","Rmaj7","<R>Maj7, <R>M7","1,3,5,7");
   chord("Major","Rmaj7+5","<R>Maj7#5, <R>M7+5","1,3,#5,7");
   chord("Major","Rmaj9","<R>Maj7(add9), <R>M7(add9)","1,3,(5),7,9");
   chord("Major","Rmaj11","<R>Maj7(add11), <R>M7(add11)","1,(3),5,7,(9),11");
   chord("Major","Rmaj13","<R>Maj7(add13), <R>M7(add13)","1,3,(5),7,(9),(11),13");
   chord("Major","R2","on guitar equivalent to: <R>add9","1,2,3,5");
   chord("Minor","Rm","<R>minor, <R>min, <R>-","1,b3,5");
   chord("Minor","Rm6","<R>minor6, <R>min6","1,b3,5,6");
   chord("Minor","Rm6/9","","1,b3,(5),6,9");
   chord("Minor","Rmmaj7","<R>min/maj7, <R>mM7, <R>m(addM7), <R>m(+7), <R>-(M7)","1,b3,5,7");
   chord("Minor","Rmmaj9","<R>min/maj9, <R>mM9, <R>m(addM9), <R>m(+9), <R>-(M9)","1,b3,(5),7,9");
   chord("Minor","Rmadd9","<R>minor(add9), <R>-(add9)","1,b3,(5),9");
   chord("Minor Seventh","Rm7","<R>minor7, <R>min7, <R>-7","1,b3,5,b7");
   chord("Minor Seventh","Rm9","<R>minor9, <R>min9, <R>-9","1,b3,(5),b7,9");
   chord("Minor Seventh","Rm11","<R>minor11, <R>min11, <R>-11","1,b3,(5),b7,(9),11");
   chord("Minor Seventh","Rm13","<R>minor13, <R>min13, <R>-13","1,b3,(5),b7,(9),(11),13");
   chord("Diminished","Rm-5","<R>m(b5)","1,b3,b5");
   chord("Diminished","Rdim","<R>�","1,b3,b5");
   chord("Diminished","Rdim7","<R>�7","1,b3,b5,bb7");
   chord("Half Diminished","Rm7-5","<R>�7, <R>�dim, <R>�dim7, <R>m(b7), <R>minor7b5","1,b3,b5,b7");
   chord("Dominant","R7","<R> dominant seventh, <R>dom","1,3,5,b7");
   chord("Dominant","R7-9","<R>7b9, <R>7(add b9)","1,3,(5),b7,b9");
   chord("Dominant","R7+9","<R>7(add#9)","1,3,(5),b7,#9");
   chord("Dominant","R7-5","<R>7b5","1,3,b5,b7");
   chord("Dominant","R7+5","<R>7+, <R>7#5","1,3,#5,b7");
   chord("Dominant","R7/6","<R>7 added 6th","1,3,(5),6,b7");
   chord("Dominant","R9","<R>7(add9)","1,3,(5),b7,9");
   chord("Dominant","R9-5","<R>9b5, <R> ninth flattened 5th","1,(3),b5,b7,9");
   chord("Dominant","R9+5","<R>9#5, <R> ninth augmented 5th","1,(3),#5,b7,9");
   chord("Dominant","Radd9","<R> added 9th, on guitar also: <R>2","1,3,5,9");
   chord("Dominant","R9/6","<R>9 added 6th","1,(3),(5),6,b7,9");
   chord("Dominant","R9+11","<R>9aug11, <R> ninth augmented 11th","1,3,(5),b7,9,#11");
   chord("Dominant","R11","<R>7(add11)","1,(3),5,b7,(9),11");
   chord("Dominant","R11-9","<R>11(b9), <R>11(flattened 9th)","1,(3),(5),b7,b9,11");
   chord("Dominant","R13","<R>7(add13)","1,(3),5,b7,(9),(11),13");
   chord("Dominant","R13-9","<R>13b9","1,(3),(5),b7,b9,(11),13");
   chord("Dominant","R13-9-5","<R>13b9b5","(1),(3),b5,b7,b9,(11),13");
   chord("Dominant","R13-9+11","<R>13b9#11","(1),(3),(5),b7,b9,#11,13");
   chord("Dominant","R13+11","<R>13 augmented 11th","1,(3),(5),b7,(9),#11,13");
   chord("Dominant","R7/13","<R>7/6","1,3,(5),b7,13");
   chord("Augmented","Raug","<R>+, <R>+5, <R>(#5), <R>augmented","1,3,#5");
   chord("Ambiguous","Rsus2","","1,2,5");
   chord("Ambiguous","Rsus4","<R>sus, <R>(sus4)","1,4,5");
   chord("Ambiguous","R7sus4","<R>7sus, <R>7sus11","1,4,5,b7");
   chord("","R-9","<R>b9, <R> flattened 9th","1,3,(5),b7,b9");
   chord("","R-9+5","<R>b9#5, <R> flattened 9th augmented 5th","1,(3),#5,b7,b9");
   chord("","R-9+11","<R>b9#11, <R> flattened 9th augmented 11th","1,(3),(5),b7,b9,#11");
   chord("","R-9-5","<R>b9b5, <R> flattened 9th flattened 5th","1,(3),b5,b7,b9");
   chord("","R+5","<R>aug5, <R> augmented 5th","1,3,#5");
   chord("","R+9","<R>aug9, <R> augmented 9th","1,3,(5),b7,#9");
   chord("","R+11","<R>aug11, <R> augmented 11th","1,(3),(5),b7,9,#11");
}

function a76()
{
   scale("Scale",":=- ����� -=:","","");
   scale("Scale","Major","","1,2,3,4,5,6,7");
   scale("Scale","Harmonic Minor","","1,2,b3,4,5,b6,7");
   scale("Scale","Melodic Minor (Ascending)","","1,2,b3,4,5,6,7");
   scale("Scale","Melodic Minor (Descending)","<R> Natural Minor, <R> Relative Minor","1,2,b3,4,5,b6,b7");
   scale("Scale","Chromatic","","1,b2,2,b3,3,4,b5,5,#5,6,b7,7");
   scale("Scale","Whole Tone","","1,2,3,#4,#5,b7");
   scale("Scale","Pentatonic Major","","1,2,3,5,6");
   scale("Scale","Pentatonic Minor","","1,b3,4,5,b7");
   scale("Scale","Pentatonic Blues","","1,b3,4,b5,5,b7");
   scale("Scale","Pentatonic Neutral","","1,2,4,5,b7");
   scale("Scale","Octatonic (H-W)","","1,b2,b3,3,b5,5,6,b7");
   scale("Scale","Octatonic (W-H)","","1,2,b3,4,b5,b6,6,7");
   scale("Scale","Ionian","<R> Major","1,2,3,4,5,6,7");
   scale("Scale","Dorian","","1,2,b3,4,5,6,b7");
   scale("Scale","Phrygian","","1,b2,b3,4,5,b6,b7");
   scale("Scale","Lydian","","1,2,3,#4,5,6,7");
   scale("Scale","Mixolydian","","1,2,3,4,5,6,b7");
   scale("Scale","Aeolian","","1,2,b3,4,5,b6,b7");
   scale("Scale","Locrian","","1,b2,b3,4,b5,b6,b7");
   scale("Scale","::: EXOTIC SCALES :::","","");
   scale("Scale","Algerian","","1,2,b3,4,#4,5,b6,7");
   scale("Scale","Arabian (a)","","1,2,b3,4,#4,#5,6,7");
   scale("Scale","Arabian (b)","","1,2,3,4,#4,#5,b7");
   scale("Scale","Augmented","","1,#2,3,#4,#5,7");
   scale("Scale","Auxiliary Diminished","","1,2,b3,4,#4,#5,6,7");
   scale("Scale","Auxiliary Augmented","","1,2,3,#4,#5,#6");
   scale("Scale","Auxiliary Diminished Blues","","1,b2,b3,3,b5,5,6,b7");
   scale("Scale","Balinese","","1,b2,b3,5,b6");
   scale("Scale","Blues","","1,b3,4,#4,5,b7");
   scale("Scale","Byzantine","","1,b2,3,4,5,b6,7");
   scale("Scale","Chinese","","1,3,#4,5,7");
   scale("Scale","Chinese Mongolian","","1,2,3,5,6");
   scale("Scale","Diatonic","","1,2,3,5,6");
   scale("Scale","Diminished","","1,2,b3,4,b5,b6,6,7");
   scale("Scale","Diminished, Half","","1,b2,b3,3,b5,5,6,b7");
   scale("Scale","Diminished, Whole","","1,2,b3,4,b5,b6,6,7");
   scale("Scale","Diminished Whole Tone","","1,b2,b3,3,b5,b6,b7");
   scale("Scale","Dominant 7th","","1,2,3,4,5,6,b7");
   scale("Scale","Double Harmonic","","1,b2,3,4,5,b6,7");
   scale("Scale","Egyptian","","1,2,4,5,b7");
   scale("Scale","Eight Tone Spanish","","1,b2,#2,3,4,b5,b6,b7");
   scale("Scale","Enigmatic","","1,b2,3,#4,#5,#6,7");
   scale("Scale","Ethiopian (A raray)","","1,2,3,4,5,6,7");
   scale("Scale","Ethiopian (Geez & Ezel)","","1,2,b3,4,5,b6,b7");
   scale("Scale","Half Diminished (Locrian)","","1,b2,b3,4,b5,b6,b7");
   scale("Scale","Half Diminished #2 (Locrian #2)","","1,2,b3,4,b5,b6,b7");
   scale("Scale","Hawaiian","","1,2,b3,4,5,6,7");
   scale("Scale","Hindu","","1,2,3,4,5,b6,b7");
   scale("Scale","Hindustan","","1,2,3,4,5,b6,b7");
   scale("Scale","Hirajoshi","","1,2,b3,5,b6");
   scale("Scale","Hungarian Major","","1,#2,3,#4,5,6,b7");
   scale("Scale","Hungarian Gypsy","","1,2,b3,#4,5,b6,7");
   scale("Scale","Hungarian Gypsy Persian","","1,b2,3,4,5,b6,7");
   scale("Scale","Hungarian Minor","","1,2,b3,#4,5,b6,7");
   scale("Scale","Japanese (A)","","1,b2,4,5,b6");
   scale("Scale","Japanese (B)","","1,2,4,5,b6");
   scale("Scale","Japanese (Ichikosucho)","","1,2,3,4,#4,5,6,7");
   scale("Scale","Japanese (Taishikicho)","","1,2,3,4,#4,5,6,#6,7");
   scale("Scale","Javaneese","","1,b2,b3,4,5,6,b7");
   scale("Scale","Jewish (Adonai Malakh)","","1,b2,2,b3,4,5,6,b7");
   scale("Scale","Jewish (Ahaba Rabba)","","1,b2,3,4,5,b6,b7");
   scale("Scale","Jewish (Magen Abot)","","1,b2,#2,3,#4,#5,#6,7");
   scale("Scale","Kumoi","","1,2,b3,5,6");
   scale("Scale","Leading Whole Tone","","1,2,3,#4,#5,#6,7");
   scale("Scale","Lydian Augmented","","1,2,3,#4,#5,6,7");
   scale("Scale","Lydian Minor","","1,2,3,#4,5,b6,b7");
   scale("Scale","Lydian Diminished","","1,2,b3,#4,5,6,7");
   scale("Scale","Major Locrian","","1,2,3,4,b5,b6,b7");
   scale("Scale","Mela Bhavapriya (44)","","1,b2,2,4,5,#5,6");
   scale("Scale","Mela Chakravakam (16)","","1,b2,3,4,5,6,b7");
   scale("Scale","Mela Chalanata (36)","","1,#2,3,4,5,#6,7");
   scale("Scale","Mela Charukesi (26)","","1,2,3,4,5,b6,b7");
   scale("Scale","Mela Chitrambari (66)","","1,2,3,#4,5,#6,7");
   scale("Scale","Mela Dharmavati (59)","","1,2,b3,#4,5,6,7");
   scale("Scale","Mela Dhatuvardhani (69)","","1,#2,3,#4,5,b6,7");
   scale("Scale","Mela Dhavalambari (49)","","1,b2,3,#4,5,#5,6");
   scale("Scale","Mela Dhenuka (9)","","1,b2,b3,4,5,b6,7");
   scale("Scale","Mela Dhirasankarabharana (29)","","1,2,3,4,5,6,7");
   scale("Scale","Mela Divyamani (48)","","1,b2,b3,#4,5,#6,7");
   scale("Scale","Mela Gamanasrama (53)","","1,b2,3,#4,5,6,7");
   scale("Scale","Mela Ganamurti (3)","","1,b2,2,4,5,b6,7");
   scale("Scale","Mela Gangeyabhusani (33)","","1,#2,3,4,5,b6,7");
   scale("Scale","Mela Gaurimanohari (23)","","1,2,b3,4,5,6,7");
   scale("Scale","Mela Gavambodhi (43)","","1,b2,b3,#4,5,#5,6");
   scale("Scale","Mela Gayakapriya (13)","","1,b2,3,4,5,#5,6");
   scale("Scale","Mela Hanumattodi (8)","","1,b2,b3,4,5,b6,b7");
   scale("Scale","Mela Harikambhoji (28)","","1,2,3,4,5,6,b7");
   scale("Scale","Mela Hatakambari (18)","","1,b2,3,4,5,#6,7");
   scale("Scale","Mela Hemavati (58)","","1,2,b3,#4,5,6,b7");
   scale("Scale","Mela Jalarnavam (38)","","1,b2,2,#4,5,b6,b7");
   scale("Scale","Mela Jhalavarali (39)","","1,b2,2,#4,5,6,b7");
   scale("Scale","Mela Jhankaradhvani (19)","","1,2,b3,4,5,#6,5,6");
   scale("Scale","Mela Jyotisvarupini (68)","","1,#2,3,#4,5,b6,b7");
   scale("Scale","Mela Kamavardhani (51)","","1,b2,3,#4,5,b6,7");
   scale("Scale","Mela Kanakangi (1)","","1,b2,2,4,5,#5,6");
   scale("Scale","Mela Kantamani (61)","","1,2,3,#4,5,#5,6");
   scale("Scale","Mela Kharaharapriya (22)","","1,2,b3,4,5,6,b7");
   scale("Scale","Mela Kiravani (21)","","1,2,b3,4,5,b6,7");
   scale("Scale","Mela Kokilapriya (11)","","1,b2,b3,4,5,6,7");
   scale("Scale","Mela Kosalam (71)","","1,#2,3,#4,5,6,7");
   scale("Scale","Mela Latangi (63)","","1,2,3,#4,5,b6,7");
   scale("Scale","Mela Manavati (5)","","1,b2,2,4,5,6,7");
   scale("Scale","Mela Mararanjani (25)","","1,2,3,4,5,#5,6");
   scale("Scale","Mela Mayamalavagaula (15)","","1,b2,3,4,5,#5,6");
   scale("Scale","Mela Mechakalyani (65)","","1,2,3,#4,5,6,7");
   scale("Scale","Mela Naganandini (30)","","1,2,3,4,5,#6,7");
   scale("Scale","Mela Namanarayani (50)","","1,b2,3,#4,5,b6,b7");
   scale("Scale","Mela Nasikabhusani (70)","","1,#2,3,#4,5,6,b7");
   scale("Scale","Mela Natabhairavi (20)","","1,2,b3,4,5,b6,b7");
   scale("Scale","Mela Natakapriya (10)","","1,b2,b3,4,5,6,b7");
   scale("Scale","Mela Navanitam (40)","","1,b2,2,#4,5,6,b7");
   scale("Scale","Mela Nitimati (60)","","1,2,b3,#4,5,#6,7");
   scale("Scale","Mela Pavani (41)","","1,b2,2,#4,5,6,7");
   scale("Scale","Mela Ragavardhani (32)","","1,#2,3,4,5,b6,b7");
   scale("Scale","Mela Raghupriya (42)","","1,b2,2,#4,5,#6,7");
   scale("Scale","Mela Ramapriya (52)","","1,b2,3,#4,5,6,b7");
   scale("Scale","Mela Rasikapriya (72)","","1,#2,3,#4,5,#6,7");
   scale("Scale","Mela Ratnangi (2)","","1,b2,2,4,5,b6,b7");
   scale("Scale","Mela Risabhapriya (62)","","1,2,3,#4,5,b6,b7");
   scale("Scale","Mela Rupavati (12)","","1,b2,b3,4,5,#6,7");
   scale("Scale","Mela Sadvidhamargini (46)","","1,b2,b3,#4,5,6,b7");
   scale("Scale","Mela Salagam (37)","","1,b2,2,#4,5,#5,6");
   scale("Scale","Mela Sanmukhapriya (56)","","1,2,b3,#4,5,b6,b7");
   scale("Scale","Mela Sarasangi (27)","","1,2,3,4,5,b6,7");
   scale("Scale","Mela Senavati (7)","","1,b2,b3,4,5,#5,6");
   scale("Scale","Mela Simhendramadhyama (57)","","1,2,b3,#4,5,b6,7");
   scale("Scale","Mela Subhapantuvarali (45)","","1,b2,b3,#4,5,b6,7");
   scale("Scale","Mela Sucharitra (67)","","1,#2,3,#4,5,#5,6");
   scale("Scale","Mela Sulini (35)","","1,#2,3,4,5,6,7");
   scale("Scale","Mela Suryakantam (17)","","1,b2,3,4,5,6,7");
   scale("Scale","Mela Suvarnangi (47)","","1,b2,2,#4,5,6,7");
   scale("Scale","Mela Syamalangi (55)","","1,2,b3,#4,5,#5,6");
   scale("Scale","Mela Tanarupi (6)","","1,b2,2,4,5,#6,7");
   scale("Scale","Mela Vaschaspati (64)","","1,2,3,#4,5,6,b7");
   scale("Scale","Mela Vagadhisvari (34)","","1,#2,3,4,5,6,b7");
   scale("Scale","Mela Vakulabharanam (14)","","1,#2,3,4,5,b6,b7");
   scale("Scale","Mela Vanaspati (4)","","1,b2,2,4,5,6,b7");
   scale("Scale","Mela Varunapriya (24)","","1,2,b3,4,5,#6,7");
   scale("Scale","Mela Visvambari (54)","","1,#2,3,#4,5,#6,7");
   scale("Scale","Mela Yagapriya (31)","","1,#2,3,4,5,#5,6");
   scale("Scale","Mohammedan","","1,2,b3,4,5,b6,7");
   scale("Scale","Neopolitan","","1,b2,b3,4,5,b6,7");
   scale("Scale","Neoploitan Major","","1,b2,b3,4,5,6,7");
   scale("Scale","Neopolitan Minor","","1,b2,b3,4,5,b6,b7");
   scale("Scale","Nine Tone Scale","","1,2,#2,3,#4,5,#5,6,7");
   scale("Scale","Oriental (a)","","1,b2,3,4,b5,b6,b7");
   scale("Scale","Oriental (b)","","1,b2,3,4,b5,6,b7");
   scale("Scale","Overtone","","1,2,3,#4,5,6,b7");
   scale("Scale","Overtone Dominant","","1,2,3,#4,5,6,b7");
   scale("Scale","Pelog","","1,b2,b3,5,b6");
   scale("Scale","Persian","","1,b2,3,4,b5,b6,7");
   scale("Scale","Prometheus","","1,2,3,b5,6,b7");
   scale("Scale","Prometheus Neopolitan","","1,b2,3,b5,6,b7");
   scale("Scale","Pure Minor","","1,2,b3,4,5,b6,b7");
   scale("Scale","Purvi Theta","","1,b2,3,#4,5,b6,7");
   scale("Scale","Roumanian Minor","","1,2,b3,#4,5,6,b7");
   scale("Scale","Six Tone Symmetrical","","1,b2,3,4,#5,6");
   scale("Scale","Spanish Gypsy","","1,b2,3,4,5,b6,b7");
   scale("Scale","Super Locrian","","1,b2,#2,3,#4,#5,b7");
   scale("Scale","Theta, Asavari","","1,2,b3,4,5,b6,b7");
   scale("Scale","Theta, Bilaval","","1,2,3,4,5,6,7");
   scale("Scale","Theta, Bhairav","","1,b2,3,4,5,b6,7");
   scale("Scale","Theta, Bhairavi","","1,b2,b3,4,5,b6,b7");
   scale("Scale","Theta, Kafi","","1,2,b3,4,5,6,b7");
   scale("Scale","Theta, Kalyan","","1,2,3,#4,5,6,7");
   scale("Scale","Theta, Khamaj","","1,2,3,4,5,6,b7");
   scale("Scale","Theta, Marva","","1,b2,3,#4,5,6,7");
   scale("Scale","Todi Theta","","1,b2,b3,#4,5,b6,7");
}

function chord( a47, a49, a53, a50)
{
   Chords[a49]=a47 + "|" + a53 + "|" + a50;
   a81++;
   b63[a81] = a49;
}

function scale( a20, a21, a53, a22 )
{
   a73[a21] = a20 + "|" + a53 + "|" + a22;
   a80++;
   a74[a80] = a21;
}

function showFingerSetting( c25 )
{
   b19=c25;
   var a33="";
   var sep="|";
   var a85=-1;
   var a84=0;
   var b53=0;
   var a23="";
   var a13="";
   var a54="";
   
   if ( b19 == "Chords" )
      {
      if ( document.aspnetForm.chordRoot.selectedIndex == -1 ) document.aspnetForm.chordRoot.selectedIndex=document.aspnetForm.scaleRoot.selectedIndex;
      if ( document.aspnetForm.chordName.selectedIndex == -1 ) document.aspnetForm.chordName.selectedIndex=c10;
      document.aspnetForm.scaleRoot.selectedIndex=-1;
      document.aspnetForm.scaleName.selectedIndex=-1;
      a25=document.aspnetForm.chordRoot.options[document.aspnetForm.chordRoot.selectedIndex].value;
      a33=document.aspnetForm.chordName.options[document.aspnetForm.chordName.selectedIndex].value;
      a23=Chords["R"+a33];
      c10=document.aspnetForm.chordName.selectedIndex;
      }
   else if( b19 == "Scales" )
      {
      if ( document.aspnetForm.scaleRoot.selectedIndex == -1 ) document.aspnetForm.scaleRoot.selectedIndex=document.aspnetForm.chordRoot.selectedIndex;
      if ( document.aspnetForm.scaleName.selectedIndex == -1 ) document.aspnetForm.scaleName.selectedIndex=c11;
      document.aspnetForm.chordRoot.selectedIndex =- 1;
      document.aspnetForm.chordName.selectedIndex =- 1;
      a25=document.aspnetForm.scaleRoot.options[document.aspnetForm.scaleRoot.selectedIndex].value;
      a33=document.aspnetForm.scaleName.options[document.aspnetForm.scaleName.selectedIndex].value;
      if ( a33.charAt(0) == ":" )
         {
         if ( document.aspnetForm.scaleName.selectedIndex !=0 && document.aspnetForm.scaleName.selectedIndex == c11-1 )
            {
            document.aspnetForm.scaleName.selectedIndex--;
            }
         else
            {
            document.aspnetForm.scaleName.selectedIndex++;
            }
         a33=document.aspnetForm.scaleName.options[document.aspnetForm.scaleName.selectedIndex].value;
         }
         a23=a73[a33];
         c11=document.aspnetForm.scaleName.selectedIndex;
      }
   else alert("������: `infoType'.\n���������� �������� �� ������ webmaster@pripev.ru.\ninfoType = "+b19+"\n�������.");
   
   a84=a23.indexOf(sep);
   while ( a84 != -1 )
      {
      b53++;
      if( b53 == 1 )
         {
         a13=a23.substring(a85+1,a84);
         }
      else if(b53==2)
         {
         a54=a23.substring(a85+1,a84);
         }
         a85=a84;
         a84=a23.indexOf(sep,a85+1);
      }
   if( root_disambig_sharp_or_flat == "b" )
      {
      if ( a25 == "Cis" ) a25="Db";
      else if ( a25 == "Dis" ) a25="Eb";
      else if ( a25 == "Fis" ) a25="Gb";
      else if ( a25 == "Gis" ) a25="Ab";
      else if ( a25 == "Ais" ) a25="Bb";
      }
   a60(a33,a23.substring(a85+1,a23.length),a13,a54,true);
}

function a60( a33, a43, a13, a54, c43 )
{
   document.aspnetForm.infoText.value="���������...   ";
   c44(a43);
   for( i=1; i < 7; i++ )
      {
      a59(i,c43);
      }
   var a10=a98("is","#",a25);
   a54=a98("<R>",a10,a54);
   document.aspnetForm.infoText.value="             " + a10 + " " + a33 + "\n";
   if ( a54 != "" ) document.aspnetForm.infoText.value+="�����������: " + a54 + "\n";
   document.aspnetForm.infoText.value+="����:        " + a43 + "\n" + "��������:    ";
   c12(a43,a13);
   for ( var i=0; i < c08.length; i++ )
      {
      document.aspnetForm.infoText.value += c08[i];
      if ( i < c08.length-1 ) document.aspnetForm.infoText.value += "-";
      }
   if ( c09.length > 0 )
      {
      document.aspnetForm.infoText.value += " (��������)\n��������:    ";
      for ( var i=0; i<c09.length; i++ )
         {
         document.aspnetForm.infoText.value += c09[i];
         if( i < c09.length-1 ) document.aspnetForm.infoText.value += "-";
         }
      document.aspnetForm.infoText.value += " (���.+���.)";
      }
   document.aspnetForm.infoText.value += "\n";
   c41=c41.substring(0,c41.length-1);
   document.aspnetForm.infoText.value+="����:        " + c41;
}

function a59(a36,c43)
{
   var c28=1+a94[a08[6-a36]]-a94[a25];
   if ( c28 < 1 ) c28+=12;
   for( var j=0; j<13; j++, c28++ )
      {
      if ( c28 > 12 ) c28=1;
      if ( c36[c28] != c34[c28] || c43 )
         {
         if ( c36[c28] == "0") b58(a36,j);
         else
            {
            var note_name=c36[c28];
            if ( displayNames == "in" )
               {
               note_name=c35[c28];
               }
            a83(a36,j,note_name);
            }
         }
      }
}

function c12(c27,c25)
{
   var c26=c27.split(",");
   var num1=1;
   var num2=1;
   var a87=false;
   var i=0;
   var j=0;
   
   c08=[];
   c09=[];
   for ( i=1; i<c26.length; i++ )
      {
      if ( c26[i].charAt(0) != "(" )
         {
         num2=b15[c26[i]];
         c08[j]=num2-num1;
         if ( c08[j] < 0 ) c08[j]+=12;
         num1=num2;
         j++;
         }
      else a87=true;
      }
   if ( c25.toLowerCase() == "scale" )
      {
      c08[i-1] = 13-num1;
      }
   num1=1;
   num2=1;
   if ( a87 )
      {
      for ( var i=1; i<c26.length; i++ )
         {
         if ( c26[i].charAt(0) == "(" )
            {
            num2 = b15[c26[i].substring(1,c26[i].length-1)];
            }
         else
            {
            num2=b15[c26[i]];
            }
         c09[i-1]=num2-num1;
         if ( c09[i-1] <0 ) c09[i-1]+=12;
         num1=num2;
         }
      if ( c25.toLowerCase() == "scale" )
         {
         c09[i-1] = 13-num1;
         }
      }
}

function b25(c27)
{
   alert("getNotesFromIntervals(" + c27 +")" );
}

function b59()
{
   var i=0;
   var j=0;
   
   for ( var i=1; i<7; i++ ) b57(i);
}

function b57( a36 )
{
   for ( var j=0; j<13; j++ ) b58(a36,j);
}

function b58( a36, b32 )
{
   if ( !b32 ) b20( "s" + a36 + "0", h.src );
   else if ( a36 >3 ) b20( "s" +a36 + b32, s_thick.src );
   else 
      {
      if ( fb_bass == "bottom" )
         {
         b20( "s" + a36 + b32, s_thin.src);
         }
      else
         {
         b20( "s" + a36 + b32, s_thin_.src );
         }
      }
   c18( "txt" + a36 + b32, "&nbsp;" );
}

function a83( a36, b32, c42)
{
   if ( c42.charAt(0) == "(" )
      {
      c42 = c42.substring(1,c42.length-1);
      b20( "s" + a36 + b32, so_.src);
      }
   else
      {
      b20( "s" + a36 + b32, sp.src);
      }
   if ( c42.substring(1,c42.length) == "##" )
      {
      c42 = a98("##","x",c42);
      }
   else if ( c42.substring(0,2) == "bb" || c42.substring(1,c42.length) == "bb" )
      {
      c42=a98("bb","<span class=\"bb\">bb</span>",c42);
      }
   c18("txt" + a36 + b32, c42);
}

function tuneUp(a36)
{
   var c30=6-a36;
   a08[c30]=eval("intervalNoToNote_" +a08[c30] + "[2]" );
   b20("s"+a36+"h",eval("h"+a08[c30]+".src"));
   a59(a36,true);
   window.status="�����: " +a08;
   b68();
}

function tuneDown(a36)
{
   var c30=6-a36;
   a08[c30]=eval("intervalNoToNote_"+a08[c30]+"[12]");
   b20("s"+a36+"h",eval("h"+a08[c30]+".src"));
   a59(a36,true);
   window.status="�����: " + a08; b68();
}

function setTuning(a14)
{
   var pos=0;
   var note="";
   window.status="�����: " + a14;
   if ( a14 == "Custom" )
      {
      window.status="��������� ������ � ������� ������ [+] � [-]";
      return;
      }
   for ( var a36=6; a36>0; a36-- )
      {
      note=a14.charAt(pos);
      if ( a14.charAt(pos+1) == "#")
         {
         note += "is";
         pos++;
         }
      else if ( a14.substring(pos+1,pos+3) == "is" )
         {
         note += "is";
         pos+=2;
         }
      var c31=6-a36;
      if ( a08[c31] != note )
         {
         a08[c31]=note;
         b20( "s" + a36 + "h", eval("h"+note+".src"));
         a59(a36,true);
         }
      pos++;
      }
}

function b68()
{
   var a31="";
   
   for ( var i=0; i<6; i++ ) a31 += a98( "is", "#", a08[i]);
   var pos=-1;
   for ( i=0; i<a07.length; i++ )
      {
      pos=a07[i].indexOf("|");
      if ( a31 == a07[i].substring(0,pos))
         {
         document.aspnetForm.TuningList.selectedIndex=i;
         return;
         }
      }
   document.aspnetForm.TuningList.selectedIndex=a07.length-1;
}

function a71(b31){}

function b69(a06)
{
   document.write( "<table border=0><tr><td valign=\"bottom\" class='rb'>");
   document.write("�����:<br><select name=\"TuningList\" size=1 class='SelectControl'" + "onChange=\"setTuning(this.options[this.selectedIndex].value);\">");
   var pos=-1;
   for ( var i=0; i<a07.length; i++)
      {
      pos=a07[i].indexOf("|");
      document.write("<option value=\"" + a07[i].substring(0,pos) +"\">" + a07[i].substring(pos+1,a07[i].length));
      }
   document.write("</select></td>");
   document.write("<td><img src=\"dot_clear.gif\" width=15 height=1></td><td><span class=\"rb\"><acronym title=\"������� ��� ������\">" +
                  "<input type=radio name=\"fb_player\" value=\"R\" onClick=\"fb_change('fb_player','R')\">���<b><u>�</u></b>��</acronym><br><acronym title=\"������� ��� �����\">"+
                  "<input type=radio name=\"fb_player\" value=\"L\" onClick=\"fb_change('fb_player','L')\">��<b><u>�</u></b>��</acronym></span></td>"+
                  "<td><img src=\"dot_clear.gif\" width=15 height=1></td><td><span class=\"rb\"><acronym title=\"���������� ���� � �������� �������� ������\">"+
                  "<input type=radio name=\"fb_bass\" value=\"top\" onClick=\"fb_change('fb_bass','top')\"><b><u>�</u></b>������ ������ ������</acronym><br>"+
                  "<acronym title=\"���������� ���� � �������� �������� �����\"><input type=radio name=\"fb_bass\" value=\"bottom\" onClick=\"fb_change('fb_bass','bottom')\"><b><u>�</u></b>������ ������ �����</acronym></span></td>");
  document.write("</tr></table>");
}

function b83(a06)
{
   document.write("<select name=\"Capo\" size=1 class='SelectControl' onChange=\"setCapo(this.options[this.selectedIndex].value);\">" +
                  "<option value=\"0\"><option value=\"1\">���� �� 1-�� ����"+"<option value=\"2\">���� �� 2-�� ����<option value=\"3\">���� �� 3-�� ����");
   for ( var i=4; i<11; i++ ) document.write("<option value=" + i + ">���� �� " + i + "-�� ����");
   document.write("</select>");
}

function b79( a06 )
{
   document.write("<table border=0 cellspacing=0 cellpadding=0 bgcolor=\"#ffffff\">");
   if ( fb_player == "R" && fb_bass == "bottom" )
      {
      b76 ( "0-12" );
      b75( "0-12", "stringsBassDown.gif" );
      b72( "nut_L", "1-6" );
      b77("0-12");
      }
   else if( fb_player == "R" && fb_bass == "top" )
      {
      b77("12-0");
      b75("12-0","stringsBassUp.gif");
      b72("nut_R","6-1");
      b76("12-0");
      }
   else if( fb_player == "L" && fb_bass == "bottom" )
      {
      b76("12-0");
      b75("12-0","stringsBassDown.gif");
      b72("nut_R","1-6");
      b77("12-0");
      }
   else if( fb_player == "L" && fb_bass == "top" )
      {
      b77("0-12");
      b75("0-12","stringsBassUp.gif");
      b72("nut_L","6-1");
      b76("0-12");
      }
   document.write("</table>");
}

function b76(a46)
{
   document.write("<tr>");
   if ( a46 == "0-12" )
      {
      document.write("<td colspan=8>&nbsp;</td>");
      for( var i=1; i<13; i++) document.write("<td colspan=1><div class=\"fretno\">" + i + "</div></td><td colspan=3>&nbsp;</td>");
      }
   else
      {
      for( var i=12; i>0; i-- ) document.write("<td colspan=3>&nbsp;</td><td colspan=1><div class=\"fretno\">" + i + "</div></td>");
      document.write("<td colspan=8>&nbsp;</td>");
      }
   document.write("</tr>");
}

function b75(a46,a16)
{
   document.write("<tr>");
   if( a46 == "0-12" )
      {
      document.write("<td colspan=3></td><td rowspan=7 valign=center><img src=\"dot_clear.gif\" width=12></td><td></td>" +
                     "<td rowspan=7 valign=center><img src=\"dot_clear.gif\" width=6></td>" +
                     "<td rowspan=7 valign=center><img src=\"dot_000000.gif\" width=4 height=102></td>");
      for( var i=12; i>0; i-- )
         {
         document.write("<td rowspan=7 valign=center><img src=\"" + a16 + "\" width=" + i + " height=120></td><td><img src=\"dot_clear.gif\"></td>" +
                        "<td rowspan=7 valign=center><img src=\"" + a16 + "\" width=" + i/2 + " height=120></td>" +
                        "<td rowspan=7 valign=center><img src=\"dot_000000.gif\" width=2 height=102></td>");
         }
      document.write("<td rowspan=7 valign=center><img src=\"" + a16 + "\" width=10 height=120></td>");
      }
   else
      {
      document.write("<td rowspan=7 valign=center><img src=\"" + a16 + "\" width=10 height=120></td>");
      for( var i=1; i<13; i++ )
         {
         document.write("<td rowspan=7 valign=center><img src=\"dot_000000.gif\" width=2 height=102></td>" +
                        "<td rowspan=7 valign=center><img src=\"" + a16 + "\" width=" +i/2 + " height=120></td>" + "<td><img src=\"dot_clear.gif\"></td>" +
                        "<td rowspan=7 valign=center><img src=\"" + a16 + "\" width=" + i + " height=120></td>");
         }
      document.write("<td rowspan=7 valign=center><img src=\"dot_000000.gif\" width=4 height=102></td>" +
                     "<td rowspan=7 valign=center><img src=\"dot_clear.gif\" width=6></td>" +
                     "<td></td><td rowspan=7 valign=center><img src=\"dot_clear.gif\" width=12></td>" +
                     "<td colspan=3></td>");
      }
   document.write("</tr>");
}

function b72(fb_nut,c45)
{
   var i=0;
   
   if ( c45 == "6-1" )
      {
      for( i=6; i>0; i-- ) b74(fb_nut,i);
      }
   else
      {
      for( i=1; i<7; i++ ) b74(fb_nut,i);
      }
}

function b74(fb_nut,a37)
{
   document.write("<tr>");
   var i=0;
   if( fb_nut == "nut_L" )
      {
      b70(a37); b73(a37); b71(a37);
      for( i=0; i<13; i++ ) b78(a37,i);
      }
   else
      {
      for( i=12; i>=0; i-- ) b78(a37,i);
      b71(a37); b73(a37); b70(a37);
      }
   document.write("</tr>");
}

function b70(a37)
{
   document.write("<td><a href=\"Javascript:tuneUp(" + a37 + ");\" onMouseOver=\"imgOn('tuneup" + a37 + "','tuneup_'); window.status='��������� ������ �� " + a37 + " ���'; return true;\" onMouseOut=\"imgOff('tuneup" + a37 + "','tuneup_'); window.status=''; return true;\"><img border=0 src=\"tuneup_off.gif\" width=20 height=20 name=\"tuneup" + a37 + "\" alt=\"��������� ������ " + a37 + "\"></a></td>");
}

function b73(a37)
{
   document.write("<td><img src=\"h" + a08[6-a37] + ".gif\" width=20 height=20 name=\"s" + a37 + "h\"alt=\"��������� ������ " + a37 + "\"></td>");
}

function b71(a37)
{
   document.write("<td><a href=\"Javascript:tuneDown(" + a37 + ");\" onMouseOver=\"imgOn('tunedown" + a37 + "','tunedown_');window.status='��������� ������ �� " + a37 + " ���';return true;\" onMouseOut=\"imgOff('tunedown" + a37 + "','tunedown_');window.status='';return true;\"><img border=0 src=\"tunedown_off.gif\" width=20 height=20 name=\"tunedown" + a37 + "\" alt=\"��������� ������ " + a37 + "\"></a></td>");
}

function b78(a37,fret_no)
{
   document.write("<td valign=\"top\">");
   document.write("<span class=\"n_img\"><img src=\"");
   if( fret_no ==0 ) document.write("h.gif");
   else if ( a37 > 3 ) document.write("s_thick.gif");
   else if ( fb_bass == "bottom" ) document.write("s_thin.gif");
   else document.write("s_thin_.gif");
   document.write("\" width=18 height=18 name=\"s" + a37 + fret_no + "\" alt=\"������ " + a37 + ", ��� " + fret_no + "\"></span>");
   document.write("<div id=\"txt" + a37 + fret_no + "\" class=\"n_txt\">&nbsp;</div>");
   document.write("</td>");
}

function b77(a46)
{
   document.write("<tr>");
   if ( a46 == "0-12" )
      {
      document.write("<td colspan=16>&nbsp;</td><td colspan=1><img src=\"fb_1dot.gif\"></td><td colspan=7>&nbsp;</td><td colspan=1><img src=\"fb_1dot.gif\"></td>" +
                     "<td colspan=7>&nbsp;</td><td colspan=1><img src=\"fb_1dot.gif\"></td><td colspan=7>&nbsp;</td><td colspan=1><img src=\"fb_1dot.gif\"></td>" +
                     "<td colspan=11>&nbsp;</td><td colspan=1><img src=\"fb_2dot.gif\"></td><td colspan=3>&nbsp;</td>");
      }
   else
      {
      document.write("<td colspan=3>&nbsp;</td><td colspan=1><img src=\"fb_2dot.gif\"></td><td colspan=11>&nbsp;</td><td colspan=1><img src=\"fb_1dot.gif\"></td>" +
                     "<td colspan=7>&nbsp;</td><td colspan=1><img src=\"fb_1dot.gif\"></td><td colspan=7>&nbsp;</td><td colspan=1><img src=\"fb_1dot.gif\"></td>" +
                     "<td colspan=7>&nbsp;</td><td colspan=1><img src=\"fb_1dot.gif\"></td><td colspan=16>&nbsp;</td>");
      }
   document.write("</tr>");
}

function b81(a06)
{
   document.write("<table border=0><tr>\n");
   document.write("<td colspan=5><table border=0 width=100%><tr>");
   document.write("<td width=180><span id=\"rb_display_names\" class=\"rb\"><acronym title=\"����: C, D, E, ���.\"><input type=radio name=\"displayNames\" value=\"nn\" onClick=\"switchInNn('nn');\"><b><u>�</u></b>��������� �������� ���</acronym><br>" +
                  "<acronym title=\"���������: 1, 2, 3, ���.\"><input type=radio name=\"displayNames\" value=\"in\" onClick=\"switchInNn('in');\"><b><u>�</u></b>��������� ���������</acronym></span><td>");
   document.write("<td width=180><span id=\"rb_spelling\" class=\"rb\"><acronym title=\"������� ��������: ������� ���� (x), ������� ������ (bb), ���.\"><input type=radio name=\"enharmonicSpelling\" value=\"STRICT\" onClick=\"switchSpelling('STRICT');\">������� <b><u>�</u></b>������� <font color=\"#666666\">(x = ##)</font></acronym><br>" +
                  "<acronym title=\"���������� ��������: ������������������� ����\"><input type=radio name=\"enharmonicSpelling\" value=\"SIMPLE\" onClick=\"switchSpelling('SIMPLE');\">���������� <b><u>�</u></b>�������</acronym></span></td>");
   document.write("<td><span id=\"rb_root\" class=\"rb\">"+"<acronym title=\"#: �������� ��� �����\"><input type=radio name=\"rootSharpOrFlat\" value=\"#\" onClick=\"switchSharpFlat('#');\">����<b><u>�</u></b>���: #</acronym><br>" +
                  "<acronym title=\"b: �������� ��� ������\">"+"<input type=radio name=\"rootSharpOrFlat\" value=\"b\" onClick=\"switchSharpFlat('b');\">����<b><u>�</u></b>���: b</acronym></span>");
   document.write("</td></tr></table></td></tr><tr>");
   document.write("<td valign=\"bottom\" bgcolor=\"#BCA472\"><img src=\"sel_chords.gif\" width=10></td>\n");
   document.write("<td><nobr><select name=\"chordRoot\" size=12 class='SelectControl' onChange=\"showFingerSetting('Chords');\">" +
                  "<option value=\"C\">C<option value=\"Cis\">C#/Db<option value=\"D\">D<option value=\"Dis\">D#/Eb<option value=\"E\">E<option value=\"F\">F" +
                  "<option value=\"Fis\">F#/Gb<option value=\"G\">G<option value=\"Gis\">G#/Ab<option value=\"A\">A<option value=\"Ais\">A#/Bb<option value=\"B\">B" +
                  "\n</select>\n");
   document.write("<select class='SelectControl' name=\"chordName\" size=12 onChange=\"showFingerSetting('Chords');\">");
   for( i=1; i<=a81; i++ )
      {
      document.write("<option value=\"" + b63[i].substring(1,b63[i].length) + "\">" + b63[i].substring(1,b63[i].length));
      }
   document.write("\n</select>");
   document.write("</nobr></td>\n");
   document.write("<td><img src=\"dot_clear.gif\" width=20></td>");
   document.write("<td valign=\"bottom\" bgcolor=\"#BCA472\"><img src=\"sel_scales.gif\" width=10></td>");
   document.write("<nobr><td>"+"<select class='SelectControl' name=\"scaleRoot\" size=12 onChange=\"showFingerSetting('Scales');\">" +
                  "<option value=\"C\">C<option value=\"Cis\">C#/Db<option value=\"D\">D<option value=\"Dis\">D#/Eb<option value=\"E\">E<option value=\"F\">F" +
                  "<option value=\"Fis\">F#/Gb<option value=\"G\">G<option value=\"Gis\">G#/Ab<option value=\"A\">A<option value=\"Ais\">A#/Bb<option value=\"B\">B" +
                  "</select>\n");
   document.write("<select class='SelectControl' name=\"scaleName\" size=12 onChange=\"showFingerSetting('Scales');\">");
   for( i=1; i<=a80; i++ )
      {
      document.write("<option value=\"" + a74[i].substring(0,a74[i].length) + "\">" + a74[i].substring(0,a74[i].length));
      }
   document.write("\n</select>");
   document.write("</nobr></td>\n");
   document.write("</tr></table>");
   document.write("<table><tr><td valign=\"bottom\" bgcolor=\"#BCA472\"><img src=\"sel_details.gif\" width=10></td><td><font face=\"CourierNew,Courier\" size=\"2\">" +
                  "<textarea name=\"infoText\" rows=6 cols=64 wrap=off  class='ta'></textarea></font></td></tr>");
   document.write("</table>");
}

function setRadioButtons()
{
   if( fb_player == "L" )
      {
      document.aspnetForm.fb_player[0].checked = 0;
      document.aspnetForm.fb_player[1].checked = 1;
      }
   else
      {
      document.aspnetForm.fb_player[0].checked = 1;
      document.aspnetForm.fb_player[1].checked = 0;
      }
   if( fb_bass == "top" )
      {
      document.aspnetForm.fb_bass[0].checked = 1;
      document.aspnetForm.fb_bass[1].checked = 0;
      }
   else
      {
      document.aspnetForm.fb_bass[0].checked = 0;
      document.aspnetForm.fb_bass[1].checked = 1;
      }
   if( displayNames == "nn" )
      {
      document.aspnetForm.displayNames[0].checked = 1;
      document.aspnetForm.displayNames[1].checked = 0;
      }
   else
      {
      document.aspnetForm.displayNames[0].checked = 0;
      document.aspnetForm.displayNames[1].checked = 1;
      }
   if( c13 == "STRICT" )
      {
      document.aspnetForm.enharmonicSpelling[0].checked=1;
      document.aspnetForm.enharmonicSpelling[1].checked=0;
      }
   else
      {
      document.aspnetForm.enharmonicSpelling[0].checked=0;
      document.aspnetForm.enharmonicSpelling[1].checked=1;
      }
   if( root_disambig_sharp_or_flat == "#" )
      {
      document.aspnetForm.rootSharpOrFlat[0].checked=1;
      document.aspnetForm.rootSharpOrFlat[1].checked=0;
      }
   else
      {
      document.aspnetForm.rootSharpOrFlat[0].checked=0;
      document.aspnetForm.rootSharpOrFlat[1].checked=1;
      }
}

function fb_change(strVarName,strValue)
{
   if( eval(strVarName) == strValue ) return;
   
   var plyr="", bass="", b19="", c29=-1, c33=-1, tune="";
   
   if( document.aspnetForm.fb_player[0].checked ) plyr = escape( document.aspnetForm.fb_player[0].value );
   else plyr = escape( document.aspnetForm.fb_player[1].value );

   if( document.aspnetForm.fb_bass[0].checked ) bass = escape(document.aspnetForm.fb_bass[0].value);
   else bass = escape(document.aspnetForm.fb_bass[1].value);

   if( document.aspnetForm.chordRoot.selectedIndex != -1 )
      {
      b19 = "Chords";
      c29 = document.aspnetForm.chordRoot.selectedIndex;
      c33 = document.aspnetForm.chordName.selectedIndex;
      }
   else
      {
      b19 = "Scales";
      c29 = document.aspnetForm.scaleRoot.selectedIndex;
      c33 = document.aspnetForm.scaleName.selectedIndex;
      }
   
   for( i=0; i<6; i++ )
      {
      if(a08[i].substring(1) == "#" ) tune += a08[i].charAt(0) + "is";
      else tune += a08[i];
      }
   document.location.replace("acc.htm?plyr=" + plyr + ",bass=" + bass + ",info=" + b19 + ",root=" + c29 + ",name=" + c33 + ",tune=" + tune + ",disp=" + displayNames );
}

function togglePlayingHand()
{
  if( document.aspnetForm.fb_player[0].checked )
     {
     document.aspnetForm.fb_player[0].checked=0;
     document.aspnetForm.fb_player[1].checked=1;
     }
  else
     {
     document.aspnetForm.fb_player[0].checked=1;
     document.aspnetForm.fb_player[1].checked=0;
     }
  if( fb_player == "L" ) fb_change("fb_player","R");
  else fb_change( "fb_player","L" );
}

function toggleBassStrings()
{
   if( document.aspnetForm.fb_bass[1].checked )
      {
      document.aspnetForm.fb_bass[0].checked=1;
      document.aspnetForm.fb_bass[1].checked=0;
      }
   else
      {
      document.aspnetForm.fb_bass[0].checked=0;
      document.aspnetForm.fb_bass[1].checked=1;
      }
   
   if( fb_bass == "bottom" ) fb_change("fb_bass","top");
   else fb_change("fb_bass","bottom");
}

function toggleInNn()
{
   if( displayNames == "in" ) switchInNn( "nn" );
   else switchInNn( "in" );
   
   setRadioButtons();
}

function switchInNn(a33)
{
   if( a33 == displayNames ) return;
   displayNames = a33;
   for( i=1; i<7; i++ ) a59(i,true);
}

function toggleSpelling()
{
   if( c13 == "STRICT" ) switchSpelling("SIMPLE");
   else switchSpelling("STRICT");
   
   setRadioButtons();
}

function switchSpelling(a33)
{
   if( a33 == c13) return;
   c13 = a33;
   showFingerSetting(b19);
}

function toggleSharpFlat()
{
   if( root_disambig_sharp_or_flat == "#" ) switchSharpFlat("b");
   else switchSharpFlat("#");
   
   setRadioButtons();
}

function switchSharpFlat(a33)
{
   if( a33 == root_disambig_sharp_or_flat )return;
   root_disambig_sharp_or_flat = a33;
   showFingerSetting(b19);
}

function setVariablesFromArgs()
{
   if( args.disp ) displayNames=args.disp;
   if( args.info == "Chords" )
      {
      document.aspnetForm.chordRoot.selectedIndex=args.root;
      document.aspnetForm.chordName.selectedIndex=args.name;
      showFingerSetting( args.info );
      }
   else if( args.info == "Scales" )
      {
      document.aspnetForm.scaleRoot.selectedIndex = args.root;
      document.aspnetForm.scaleName.selectedIndex = args.name;
      showFingerSetting( args.info );
      }
      
   if( args.tune )
      {
      setTuning( args.tune );
      b68();
      }
}

function imgOn(a33,b21)
{
   b20(a33,eval(b21+"on.src"));
}

function imgOff(a33,b21)
{
   b20(a33,eval(b21+"off.src"));
}

function b20(name,a58)
{
   if( document[name].src != a58 ) document[name].src=a58;
}

function c44(a43)
{
   var sep=",", a85=-1, a84=0, c40="", b09=true, c39=0, c41="";
   
   for( var i=1; i<13; i++ ) c34[i]=c36[i];
   for( var i=1; i<13; i++ ) c37[i]=c35[i];
   for( var i=1; i<13; i++ ) c36[i]=0;
   for( var i=1; i<13; i++ ) c35[i]=0;
   a84=a43.indexOf(sep);
   while( b09 )
      {
      if( a84 != -1 ) c40 = a43.substring(a85+1,a84);
      else
         {
         c40=a43.substring(a85+1,a43.length);
         b09=false;
         }
      if( c40.charAt(0) == "(" ) c39=c40.substring(1,c40.length-1);
      else c39=c40;
      
      c35[b15[c39]]=c40;
      c36[b15[c39]]=c23(c40,c13);
      c41 += c23(c40,"STRICT") + ",";
      
      if(a84 != -1)
         {
         a85=a84;
         a84=a43.indexOf(sep,a85+1);
         }
      }
}

function c23(c40,strict_or_simple)
{
   var flagOptional=false;
   
   if( c40.charAt(0) == "(" )
      {
      flagOptional=true;
      c40=c40.substring(1,c40.length-1);
      }
   var c22=c40.substring(c17(c40));
   var c20=c40.substring(0,c17(c40));
   
   if( c22 > 7 ) c22-=7;
   
   var c14=c38[a25][c22-1];
   
   for( var i=0; i<c20.length; i++ )
      {
      if( c20.charAt(i) == 'b' ) c14=c15(c14,strict_or_simple);
      else if( c20.charAt(i) == '#' ) c14=c16(c14,strict_or_simple);
      else alert("������: ����������� ������ � `interval_adjustment'.\n���������� �������� �� ������ �� ������ webmaster@pripev.ru" );
      }
   
   if( strict_or_simple == "SIMPLE" )
      {
      if( c14 == "Cbb" ) c14="Bb";
      else if( c14 == "A##" || c14 == "Cb"  ) c14="B";
      else if( c14 == "B#"  || c14 == "Dbb" ) c14="C";
      else if( c14 == "B##" ) c14="C#";
      else if( c14 == "C##" || c14 == "Ebb" ) c14="D";
      else if( c14 == "Fbb" ) c14 = "Eb";
      else if( c14 == "D##" || c14 == "Fb"  ) c14 = "E";
      else if( c14 == "E#"  || c14 == "Gbb" ) c14 = "F";
      else if( c14 == "E##" ) c14 = "F#";
      else if( c14 == "F##" || c14 == "Abb" ) c14 = "G";
      else if( c14 == "G##" || c14 == "Bbb" ) c14 = "A";
      }
   if( flagOptional ) c14 = "(" + c14 + ")";
   return c14;
}

function c15(c14,strict_or_simple)
{
   if( c14.length == 1 ) c14 += "b";
   else if( c14.charAt(c14.length-1) == "#" ) c14 = c14.substring(0,c14.length-1);
   else if( c14.substring(c14.length-2) == "bb" )
      {
      if( c14 == "Cbb" && strict_or_simple == "STRICT" ) c14="Bbb";
      else if( c14 == "Cbb" && strict_or_simple == "SIMPLE" ) c14 = "A";
      else if( c14 == "Bbb" ) c14 = "Ab";
      else if( c14 == "Abb" ) c14 = "Gb";
      else if( c14 == "Gbb" ) c14 = "Fb";
      else if( c14 == "Fbb" && strict_or_simple == "STRICT" ) c14 = "Ebb";
      else if( c14 == "Fbb" && strict_or_simple == "SIMPLE" ) c14 = "D";
      else if( c14 == "Ebb" ) c14 = "Db";
      else if( c14 == "Dbb" ) c14 = "Cb";
      }
   else if( c14.charAt(c14.length-1) == "b" && strict_or_simple == "STRICT" ) c14 = c14 + "b";
   else if( c14.charAt(c14.length-1) == "b" && strict_or_simple == "SIMPLE" )
      {
      if( c14 == "Cb" ) c14 = "Bb";
      else if( c14 == "Bb" ) c14 = "A";
      else if( c14 == "Ab" ) c14 = "G";
      else if( c14 == "Gb" ) c14 = "F";
      else if( c14 == "Fb" ) c14 = "Eb";
      else if( c14 == "Eb" ) c14 = "D";
      else if( c14 == "Db" ) c14 = "C";
      }
   else alert("������: ����������� �������� '" + c14 + "' ������� `lower_one_half_step'.\n���������� �������� �� ������ �� ������ webmaster@pripev.ru");
   return c14;
}

function c16(c14,strict_or_simple)
{
   if( c14.length == 1 ) c14 += "#";
   else if( c14.charAt(c14.length-1) == "b" ) c14=c14.substring(0,c14.length-1);
   else if( c14.substring(c14.length-2) == "##" )
      {
      if( c14 == "E##" && strict_or_simple == "STRICT" ) c14 = "F##";
      else if( c14 == "E##" && strict_or_simple == "SIMPLE" ) c14 = "G";
      else if( c14 == "F##" ) c14 = "G#";
      else if( c14 == "G##" ) c14 = "A#";
      else if( c14 == "A##" ) c14 = "B#";
      else if( c14 == "B##" && strict_or_simple == "STRICT" ) c14 = "C##";
      else if( c14 == "B##" && strict_or_simple == "SIMPLE" ) c14 = "D";
      else if( c14 == "C##" ) c14 = "D#";
      else if( c14 == "D##" ) c14 = "E#";
      }
   else if( c14.charAt(c14.length-1) == "#" && strict_or_simple == "STRICT" ) c14=c14 + "#";
   else if( c14.charAt(c14.length-1) == "#" && strict_or_simple == "SIMPLE" )
      {
      if( c14 == "C#" ) c14 = "D";
      else if( c14 == "D#" ) c14 = "E";
      else if( c14 == "E#" ) c14 = "F#";
      else if( c14 == "F#" ) c14 = "G";
      else if( c14 == "G#" ) c14 = "A";
      else if( c14 == "A#" ) c14 = "B";
      else if( c14 == "B#" ) c14 = "C#";
      }
   else alert("������: ����������� �������� '" + c14 + "' ������� `raise_one_half_step'.\n���������� �������� �� ������ �� ������ webmaster@pripev.ru");
   return c14;
}

function c17(str)
{
   var intstring="0123456789";
   
   for( var i=0; i<str.length; i++ )
      if( intstring.indexOf(str.charAt(i)) != -1 ) return i;

   return -1;
}

function c18(id,str)
{
   if( document.getElementById ) document.getElementById(id).innerHTML = str;
   else if( document.all ) document.all[id].innerHTML=str;
   else if( document.layers )
      {
      with( document[id].document )
         {
         open();
         write( str );
         close();
         }
      }
}

function a98(a28,a32,a17)
{
   var a85=-1, a84=0, tmp="", b09=true;
   
   while( b09 )
      {
      a84=a17.indexOf(a28,a85+1);
      if( a84 != -1 )
         {
         tmp += a17.substring(a85+1,a84)+a32;
         a85=a84+a28.length-1;
         }
      else
         {
         tmp += a17.substring(a85+1,a17.length);
         b09=false;
         }
      }
   
   return tmp;
}

function b27()
{
   var args=new Object(), query=location.search.substring(1), pairs=query.split(",");
   
   for( var i=0; i<pairs.length; i++ )
      {
      var pos=pairs[i].indexOf("=");
      if( pos == -1 ) continue;
      
      var c32=pairs[i].substring(0,pos), value=pairs[i].substring(pos+1);
      
      args[c32]=unescape(value);
      }
      
   return args;
}
