- `DecoderValidationFallback` uses � (U+FFFD, "REPLACEMENT CHARACTER") as replacement 
character now instead of ⬜ (U+2B1C, "WHITE LARGE SQUARE"). This fixes the issue that ⬜ could
have semantic meaning under certain circumstances.


> **Project reference:** On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.