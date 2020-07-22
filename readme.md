# TextToSubStationAlpha

## What is TextToSubStationAlpha?
TextToSubStationAlpha is a simple program that takes a text file with timestamps and text and turns it into [Advanced SubSstation Alpha](https://en.wikipedia.org/wiki/SubStation_Alpha) subtitles in either the `.ass` or `.ssa` file extension.

## Examples
- This project came about when a Chinese friend recommended a drawing video to me. He made translations and made a subtitle file.
    - [Original Video](https://youtu.be/ZPd82SrT3BE)
    - Subtitled Video: Coming Soon.
    - All examples in this document that aren't cited come from this video.
- More coming soon~!

## How do I run it?
You can get the latest binaries from the [releases tab](https://github.com/MechaDragonX/TextToSubStationAlpha/releases). **There are Windows, macOS, and Linux builds available for the terminal program.**

## How does this work and how do I use it?
There are two files necesarry to make this work, a header file and translation file.
### Header
In SubStation Alpha files, there are various lines that define various information, such as
- Text Position
- Text Formatting
- Styles
- Font
- Text Color
- Pre-definted style sets (dialogue, on screen text, editor's notes)
An example of this can be seen on the [Wikipedia article for SubStaiton Alpha](https://en.wikipedia.org/wiki/SubStation_Alpha)
```
[Script Info]
; Script generated by Aegisub
; http://www.aegisub.org
Title: Neon Genesis Evangelion - Episode 26 (neutral Spanish)
Original Script: RoRo
Script Updated By: version 2.8.01
ScriptType: v4.00+
Collisions: Normal
PlayResY: 600
PlayDepth: 0
Timer: 100,0000
Video Aspect Ratio: 0
Video Zoom: 6
Video Position: 0
 
[V4+ Styles]
Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding
Style: DefaultVCD, Arial,28,&H00B4FCFC,&H00B4FCFC,&H00000008,&H80000008,-1,0,0,0,100,100,0.00,0.00,1,1.00,2.00,2,30,30,30,0
 
[Events]
Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text
Dialogue: 0,0:00:01.18,0:00:06.85,DefaultVCD, NTP,0000,0000,0000,,{\pos(400,570)}Like an Angel with pity on nobody\NThe second line in subtitle
```
This file is written to the beginning of the output file before getting the translations.
### Translations
The format for this is very simple. Here is an example:
![Table Format](https://i.imgur.com/mAUdE6R.png "Table Format")
The simplest method to create the translation file is to create an spreadsheet Microsoft Excel (I cannot confirm if Google, LibreOffice, or Open Office works) with this format. When you select everything, copy, and then paste the contents into a text, each item will be delimited (separated) by a tab. As you can see here:
```
0:00 (Onscreen)	The Process to Make a Masterpiece	
0:02	How do you start a complete piece?	
0:03	How much do you need to draw before you can say you completed it?	
0:04	After drawing the character, how do I add the background?	
0:06	Today, let's take a look	村民 means "villagers", referring to the audience, while narrator refers to himself as 村长, which means "village chief".
0:08	The Process to Make a Masterpiece	
0:11 (Onscreen)	How to Start Drawing	
0:13	If you can't bring yourself to start a masterpiece	
0:14	It's not a problem about skill	
0:16	It's because you are Virgo	In popular mainstream Astrology, Virgo is associated with being shy.
0:17	Hey, aren't you Virgo?	
```
*Make sure to remove the table headers!*
The program will read this and produce subtitle lines that start on the timestamp and end on the timestamp for the next. Secondary text lines will have the same timestamp as it's corresponding primary text line. As long as there are no issues in the input file, such as `;` instead of `:` in the timestamp, it should work perfectly!

## What isn't supported?
- Timestamps above 59 minutes (`1:23:45`)
    - Unsupported
- Timestamps with milliseconds (`0:23.36`)
    - Unsupported
- Karaoke style subtitles or other fancy formatting
    - [Example](https://youtu.be/il4cAeVzZwI) (Japanese subtitles in that video created by creator of the [YTSubtitleConvertor repo](https://github.com/arcusmaximus/YTSubConverter))
    - Unspported
    - I don't know how this works and I don't intend to support it.
