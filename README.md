
# Exanima Resource Editor
This is a GUI application to allow the community to edit or change resource packed files.

# Howto:
You cannot launch the exe, you must supply it arguments via console or windows explorer drag & drop.  
Drag the RPK file onto the executable. You will be displayed with the packed filenames.
![DragAndDrop](https://raw.githubusercontent.com/PoofImaFox/ExanimaResourceEditor/master/HowToLaunch.gif)

![UserInterface](https://i.gyazo.com/391c3a0dc16994f39f694bcb1daf99fb.png)

# Reverse File Data And Names:
This button will reverse the file data and the file names. So the last item in the list becomes the data for the first item in the list reversing all the packed files in their respective order. This operation is reversible by doing it again.

# Randomize File Data And Names:
This button will randomize the file data. Much like reverse this will use the existing files but randomize the data for each file name. This is not a reversible routine like the reverse file names.

# Edit All Regex Matches:
This button will allow you to edit all files matching your regex supplied inside of 'patterns.regex'. You may select a file after unpacking to replace all the matched files with.

# Quick View Selected:
This button will quick play the file via your default file player.  
Eg: .wav -> Media player

# Unpack All Files:
This button will allow you to unpack all the files into a specified directory.

# Edit:
This button will allow you to edit a single file. After you edit a file you will need to re-pack the resource file. This can be accomplished by pressing the "Re-Pack To Resource" button.

# Re-Pack To Resource:
This button will allow you to repack the resources after editing them. This is used with the edit button.

# Regex Matching
This dropdown button will allow you to enable, disable, and edit the regex filter for your current view. This regex filter is the same filter used to edit the files.
