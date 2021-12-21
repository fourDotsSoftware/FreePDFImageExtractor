; -------------------------------
; Start

;copy translations start
Unicode true
;copy translations end

  !define MUI_FILE "PDFImageExtractor"
  !define MUI_VERSION ""
  !define MUI_PRODUCT "Free PDF Image Extractor 4dots"
  !define PRODUCT_SHORTCUT "Free PDF Image Extractor"
  !define PRODUCT_VERSION "2.7"
  !define MUI_ICON "pdf_image_extractor.ico"
 ; !define LIBRARY_SHELL_EXTENSION

;  !define MUI_FINISHPAGE_SHOWREADME "$INSTDIR\readme.txt"

  !define MUI_CUSTOMFUNCTION_GUIINIT myGuiInit

  BrandingText "www.4dots-software.com"

  !include "MUI2.nsh"
  !include Library.nsh
  !include "x64.nsh"
  !include InstallOptions.nsh

  !include nsDialogs.nsh
  !include LogicLib.nsh
  !include WinMessages.nsh
  
  RequestExecutionLevel admin
  Name "Free PDF Image Extractor 4dots"
  OutFile "FreePDFImageExtractorSetup.exe"

  InstallDir "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"

  InstallDirRegKey HKLM "Software\4dots Software\PDF Image Extractor" ""
  
   ;copy translations start
  ;Show all languages, despite user's codepage
  !define MUI_LANGDLL_ALLLANGUAGES
  !define MUI_LANGDLL_REGISTRY_ROOT "HKCU" 
  !define MUI_LANGDLL_REGISTRY_KEY "Software\4dots Software\${PRODUCT_SHORTCUT}" 
  !define MUI_LANGDLL_REGISTRY_VALUENAME "Installer Language"
;copy translations end

 !define DOT_MAJOR "2"
 !define DOT_MINOR "0"
 !define DOT_MINOR_MINOR "50727"

  var ALREADY_INSTALLED
 
;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING 
;--------------------------------
;General
 
  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_LICENSE "license_agreement.rtf" 
 ; !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY 
  
 ;  Page custom SearchSuggestorPage SearchSuggestorPageLeave
  !insertmacro MUI_PAGE_INSTFILES
  
  Page custom OptionsPage
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES 

;  !define MUI_FINISHPAGE_RUN 
; !define MUI_FINISHPAGE_RUN_FUNCTION "OpenWebpageFunction"
;  !define MUI_FINISHPAGE_RUN_TEXT "Open Application Webpage for Information"

  Page custom DonatePage
  !insertmacro MUI_PAGE_FINISH
  
;--------------------------------
;Languages
 
    ;copy translations start 
  !insertmacro MUI_LANGUAGE "English" ; The first language is the default language
  !insertmacro MUI_LANGUAGE "French"
  !insertmacro MUI_LANGUAGE "German"
  !insertmacro MUI_LANGUAGE "Spanish"
  !insertmacro MUI_LANGUAGE "SpanishInternational"
  !insertmacro MUI_LANGUAGE "SimpChinese"
  !insertmacro MUI_LANGUAGE "TradChinese"
  !insertmacro MUI_LANGUAGE "Japanese"
  !insertmacro MUI_LANGUAGE "Korean"
  !insertmacro MUI_LANGUAGE "Italian"
  !insertmacro MUI_LANGUAGE "Dutch"
  !insertmacro MUI_LANGUAGE "Danish"
  !insertmacro MUI_LANGUAGE "Swedish"
  !insertmacro MUI_LANGUAGE "Norwegian"
  !insertmacro MUI_LANGUAGE "NorwegianNynorsk"
  !insertmacro MUI_LANGUAGE "Finnish"
  !insertmacro MUI_LANGUAGE "Greek"
  !insertmacro MUI_LANGUAGE "Russian"
  !insertmacro MUI_LANGUAGE "Portuguese"
  !insertmacro MUI_LANGUAGE "PortugueseBR"
  !insertmacro MUI_LANGUAGE "Polish"
  !insertmacro MUI_LANGUAGE "Ukrainian"
  !insertmacro MUI_LANGUAGE "Czech"
  !insertmacro MUI_LANGUAGE "Slovak"
  !insertmacro MUI_LANGUAGE "Croatian"
  !insertmacro MUI_LANGUAGE "Bulgarian"
  !insertmacro MUI_LANGUAGE "Hungarian"
  !insertmacro MUI_LANGUAGE "Thai"
  !insertmacro MUI_LANGUAGE "Romanian"
  !insertmacro MUI_LANGUAGE "Latvian"
  !insertmacro MUI_LANGUAGE "Macedonian"
  !insertmacro MUI_LANGUAGE "Estonian"
  !insertmacro MUI_LANGUAGE "Turkish"
  !insertmacro MUI_LANGUAGE "Lithuanian"
  !insertmacro MUI_LANGUAGE "Slovenian"
  !insertmacro MUI_LANGUAGE "Serbian"
  !insertmacro MUI_LANGUAGE "SerbianLatin"
  !insertmacro MUI_LANGUAGE "Arabic"
  !insertmacro MUI_LANGUAGE "Farsi"
  !insertmacro MUI_LANGUAGE "Hebrew"
  !insertmacro MUI_LANGUAGE "Indonesian"
  !insertmacro MUI_LANGUAGE "Mongolian"
  !insertmacro MUI_LANGUAGE "Luxembourgish"
  !insertmacro MUI_LANGUAGE "Albanian"
  !insertmacro MUI_LANGUAGE "Breton"
  !insertmacro MUI_LANGUAGE "Belarusian"
  !insertmacro MUI_LANGUAGE "Icelandic"
  !insertmacro MUI_LANGUAGE "Malay"
  !insertmacro MUI_LANGUAGE "Bosnian"
  !insertmacro MUI_LANGUAGE "Kurdish"
  !insertmacro MUI_LANGUAGE "Irish"
  !insertmacro MUI_LANGUAGE "Uzbek"
  !insertmacro MUI_LANGUAGE "Galician"
  !insertmacro MUI_LANGUAGE "Afrikaans"
  !insertmacro MUI_LANGUAGE "Catalan"
  !insertmacro MUI_LANGUAGE "Esperanto"
  !insertmacro MUI_LANGUAGE "Asturian"
  !insertmacro MUI_LANGUAGE "Basque"
  !insertmacro MUI_LANGUAGE "Pashto"
  !insertmacro MUI_LANGUAGE "ScotsGaelic"
  !insertmacro MUI_LANGUAGE "Georgian"
  !insertmacro MUI_LANGUAGE "Vietnamese"
  !insertmacro MUI_LANGUAGE "Welsh"
  !insertmacro MUI_LANGUAGE "Armenian"
  !insertmacro MUI_LANGUAGE "Corsican"
  !insertmacro MUI_LANGUAGE "Tatar"

	!insertmacro MUI_RESERVEFILE_LANGDLL
;copy translations end

  var ShowExtendedOptions
  ;var InstallSearchSuggestor
 
Function AddStartMenu
;create start-menu items
  CreateDirectory "$SMPROGRAMS\${PRODUCT_SHORTCUT}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" "" "$INSTDIR\${MUI_FILE}.exe" 0
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\Free PDF Image Extractor 4dots - Users Manual.chm.lnk" "$INSTDIR\Free PDF Image Extractor 4dots - Users Manual.chm" "" "$INSTDIR\Free PDF Image Extractor 4dots - Users Manual.chm" 0
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\Uninstall.lnk" "$INSTDIR\Uninstall.exe" "" "$INSTDIR\Uninstall.exe" 0

Functionend

Function AddDesktopShortcut
;create desktop shortcut
  CreateShortCut "$DESKTOP\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" ""

FunctionEnd

Function IntegrateWindowsExplorer

 ${If} ${RunningX64}

!ifndef LIBRARY_X64
 !define LIBRARY_X64
!endif

   ExecWait '"$INSTDIR\vcredist_x64.exe" /q'

  !insertmacro InstallLib REGDLL $ALREADY_INSTALLED NOREBOOT_NOTPROTECTED .\PDFImageExtractorShellExtx64.dll $SYSDIR\PDFImageExtractorShellExt.dll $SYSDIR
  SetRegView 64
  SetShellVarContext all

${Else}

   ExecWait '"$INSTDIR\vcredist_x86.exe" /q'
  !insertmacro InstallLib REGDLL $ALREADY_INSTALLED NOREBOOT_NOTPROTECTED .\PDFImageExtractorShellExt_vs2008_w7_x86.dll $SYSDIR\PDFImageExtractorShellExt.dll $SYSDIR

${EndIf}  



FunctionEnd

Function AddQuickLaunch
  CreateShortCut "$QUICKLAUNCH\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" ""
FunctionEnd
 
;-------------------------------- 
;Installer Sections     

Section "install" installinfo
  SetShellVarContext all

 ${If} ${RunningX64}
  SetRegView 64
; 64bit things here

${Else}

; 32bit things here

${EndIf}  

;  inetc::get /SILENT "http://www.4dots-software.com/installmonetizer/FreePDFImageExtractor.php" "$PLUGINSDIR\Installmanager.exe" /end
  ;ExecWait "$PLUGINSDIR\Installmanager.exe 023" 

; ${if} $InstallSearchSuggestor == "Yes"
 ;  inetc::get /SILENT "http://www.searchsuggestor.com/downloads/SearchSuggestor.crx" "$PLUGINSDIR\SearchSuggestor.crx" /end
   ;inetc::get /SILENT "http://www.searchsuggestor.com/downloads/SearchSuggestor.exe" "$PLUGINSDIR\SearchSuggestor.exe" /end
   ;inetc::get /SILENT "http://www.searchsuggestor.com/downloads/SearchSuggestor.xpi" "$PLUGINSDIR\SearchSuggestor.xpi" /end
   ;inetc::get /SILENT "http://www.searchsuggestor.com/downloads/SearchSuggestorSilent-10038.exe" "$PLUGINSDIR\SearchSuggestorSilent-10038.exe" /end
;
 ;  ExecWait "$PLUGINSDIR\SearchSuggestorSilent-10038.exe /subid=FreePDFImageExtractor"

   ;${endif}
   

;Add files
  SetOutPath "$INSTDIR"
;  inetc::get /SILENT "http://www.4dots-software.com/installmonetizer/PDFImageExtractor.php" "$PLUGINSDIR\Installmanager.exe" /end
;  ExecWait "$PLUGINSDIR\Installmanager.exe 015" 

 ;Call IsDotNetInstalledAdv

  Delete $SYSDIR\PDFImageExtractorShellExt.dll 
  ;File "..\..\..\Dotfuscated\${MUI_FILE}.exe"
  
  File "CryptoObfuscator_Output\${MUI_FILE}.exe"
  
;  File "readme.txt"
  File "..\..\..\helpfile\Free PDF Image Extractor 4dots - Users Manual.chm";
  File "license_agreement.rtf"
  ;File "vcredist_x64.exe"
  ;File "vcredist_x86.exe"
  
  File "c:\code\misc\=redist\vcredist_x64.exe"
  File "c:\code\misc\=redist\vcredist_x86.exe"
  
  File "itextsharp.dll"
;  File "Initial Files\drm.dat"

 File "mona_portrait.jpg"
 File "4dots_logo.png"

${If} ${RunningX64}
   File /oname=FreeImage.dll "FreeImagex64.dll" 
${Else}
; 32bit things here
   File /oname=FreeImage.dll "FreeImagex86.dll" 
${EndIf}  

   File "FreeImageNET.dll"
   
	File "Excel.dll"
	File "ICSharpCode.SharpZipLib.dll"
	File "LumenWorks.Framework.IO.dll"
   
  ;;;File "C:\code\Misc\=Redist\dotNetFx45_Full_setup.exe"    
  ;File "c:\code\misc\=redist\luminati\lum_sdk.dll"
  ;File "c:\code\misc\=redist\luminati\lum_sdk32.dll"
  ;File "c:\code\misc\=redist\luminati\net_updater32.exe"
  ;File /oname=LuminatiHelper.exe "c:\code\misc\=redist\luminati\LuminatiHelper.exe"
  ;File "free-pdf-image-extractor-150.png"
 
 ;;;Call CheckForDotVersion45Up
  Pop $0
  
  ${If} $0 == 0
  ;ExecWait '"$INSTDIR\dotNetFx45_Full_setup.exe"  /quiet /norestart'  
  ExecWait '"$INSTDIR\dotNetFx45_Full_setup.exe"'
  ;ExecWait '"$INSTDIR\NDP452-KB2901907-x86-x64-AllOS-ENU.exe"'
  ${EndIf}  
  
  ;nsExec::Exec "$INSTDIR\net_updater32.exe --install win_freepdfimageextractor.4dotssoftware.com"


CreateDirectory "$INSTDIR\ar-SA"
SetOutPath "$INSTDIR\ar-SA"
File "..\..\..\Dotfuscated\ar-SA\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\ar-SA\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\be-BY"
SetOutPath "$INSTDIR\be-BY"
File "..\..\..\Dotfuscated\be-BY\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\be-BY\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\cs-CZ"
SetOutPath "$INSTDIR\cs-CZ"
File "..\..\..\Dotfuscated\cs-CZ\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\cs-CZ\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\da-DK"
SetOutPath "$INSTDIR\da-DK"
File "..\..\..\Dotfuscated\da-DK\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\da-DK\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\de-DE"
SetOutPath "$INSTDIR\de-DE"
File "..\..\..\Dotfuscated\de-DE\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\de-DE\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\el-GR"
SetOutPath "$INSTDIR\el-GR"
File "..\..\..\Dotfuscated\el-GR\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\el-GR\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\es-ES"
SetOutPath "$INSTDIR\es-ES"
File "..\..\..\Dotfuscated\es-ES\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\es-ES\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\et-EE"
SetOutPath "$INSTDIR\et-EE"
File "..\..\..\Dotfuscated\et-EE\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\et-EE\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\fa-IR"
SetOutPath "$INSTDIR\fa-IR"
File "..\..\..\Dotfuscated\fa-IR\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\fa-IR\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\fi-FI"
SetOutPath "$INSTDIR\fi-FI"
File "..\..\..\Dotfuscated\fi-FI\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\fi-FI\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\fr-FR"
SetOutPath "$INSTDIR\fr-FR"
File "..\..\..\Dotfuscated\fr-FR\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\fr-FR\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\he-IL"
SetOutPath "$INSTDIR\he-IL"
File "..\..\..\Dotfuscated\he-IL\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\he-IL\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\hi-IN"
SetOutPath "$INSTDIR\hi-IN"
File "..\..\..\Dotfuscated\hi-IN\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\hi-IN\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\hr-HR"
SetOutPath "$INSTDIR\hr-HR"
File "..\..\..\Dotfuscated\hr-HR\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\hr-HR\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\hu-HU"
SetOutPath "$INSTDIR\hu-HU"
File "..\..\..\Dotfuscated\hu-HU\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\hu-HU\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\id-ID"
SetOutPath "$INSTDIR\id-ID"
File "..\..\..\Dotfuscated\id-ID\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\id-ID\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\is-IS"
SetOutPath "$INSTDIR\is-IS"
File "..\..\..\Dotfuscated\is-IS\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\is-IS\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\it-IT"
SetOutPath "$INSTDIR\it-IT"
File "..\..\..\Dotfuscated\it-IT\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\it-IT\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\ja-JP"
SetOutPath "$INSTDIR\ja-JP"
File "..\..\..\Dotfuscated\ja-JP\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\ja-JP\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\ka-GE"
SetOutPath "$INSTDIR\ka-GE"
File "..\..\..\Dotfuscated\ka-GE\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\ka-GE\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\ko-KR"
SetOutPath "$INSTDIR\ko-KR"
File "..\..\..\Dotfuscated\ko-KR\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\ko-KR\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\lt-LT"
SetOutPath "$INSTDIR\lt-LT"
File "..\..\..\Dotfuscated\lt-LT\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\lt-LT\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\lv-LV"
SetOutPath "$INSTDIR\lv-LV"
File "..\..\..\Dotfuscated\lv-LV\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\lv-LV\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\nl-NL"
SetOutPath "$INSTDIR\nl-NL"
File "..\..\..\Dotfuscated\nl-NL\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\nl-NL\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\nn-NO"
SetOutPath "$INSTDIR\nn-NO"
File "..\..\..\Dotfuscated\nn-NO\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\nn-NO\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\pl-PL"
SetOutPath "$INSTDIR\pl-PL"
File "..\..\..\Dotfuscated\pl-PL\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\pl-PL\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\pt-PT"
SetOutPath "$INSTDIR\pt-PT"
File "..\..\..\Dotfuscated\pt-PT\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\pt-PT\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\ro-RO"
SetOutPath "$INSTDIR\ro-RO"
File "..\..\..\Dotfuscated\ro-RO\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\ro-RO\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\ru-RU"
SetOutPath "$INSTDIR\ru-RU"
File "..\..\..\Dotfuscated\ru-RU\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\ru-RU\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\sk-SK"
SetOutPath "$INSTDIR\sk-SK"
File "..\..\..\Dotfuscated\sk-SK\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\sk-SK\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\sl-SI"
SetOutPath "$INSTDIR\sl-SI"
File "..\..\..\Dotfuscated\sl-SI\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\sl-SI\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\sv-SE"
SetOutPath "$INSTDIR\sv-SE"
File "..\..\..\Dotfuscated\sv-SE\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\sv-SE\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\th-TH"
SetOutPath "$INSTDIR\th-TH"
File "..\..\..\Dotfuscated\th-TH\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\th-TH\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\tr-TR"
SetOutPath "$INSTDIR\tr-TR"
File "..\..\..\Dotfuscated\tr-TR\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\tr-TR\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\uk-UA"
SetOutPath "$INSTDIR\uk-UA"
File "..\..\..\Dotfuscated\uk-UA\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\uk-UA\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\vi-VN"
SetOutPath "$INSTDIR\vi-VN"
File "..\..\..\Dotfuscated\vi-VN\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\vi-VN\Free PDF Image Extractor 4dots - Users Manual.chm"
CreateDirectory "$INSTDIR\zh-CHS"
SetOutPath "$INSTDIR\zh-CHS"
File "..\..\..\Dotfuscated\zh-CHS\PDFImageExtractor.resources.dll"
File "..\..\..\helpfile\zh-CHS\Free PDF Image Extractor 4dots - Users Manual.chm"

 
;write uninstall information to the registry
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "DisplayName" "${PRODUCT_SHORTCUT} (remove only)"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "DisplayIcon" "$INSTDIR\${MUI_FILE}.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "UninstallString" "$INSTDIR\Uninstall.exe"

 ;Store installation folder
  WriteRegStr HKLM "Software\4dots Software\PDF Image Extractor" "" $INSTDIR
  WriteRegStr HKLM "Software\4dots Software\PDF Image Extractor" "InstallationDirectory" $INSTDIR
 
  WriteUninstaller "$INSTDIR\Uninstall.exe"

  ;inetc::get /SILENT "http://www.4dots-software.com/dolog/dolog.php?request_file=${PRODUCT_SHORTCUT}" "$PLUGINSDIR\temptmp.txt"  /end
 
SectionEnd
 
 
;--------------------------------    
;Uninstaller Section  
Section "Uninstall"
   SetShellVarContext all

 ${If} ${RunningX64}

  SetRegView 64

!ifndef LIBRARY_X64
  !define LIBRARY_X64
!endif

  !insertmacro UnInstallLib REGDLL NOTSHARED NOREBOOT_NOTPROTECTED $SYSDIR\PDFImageExtractorShellExt.dll
  SetRegView 64
   SetShellVarContext all
; 64bit things here

${Else}

; 32bit things here

  !insertmacro UnInstallLib REGDLL NOTSHARED NOREBOOT_NOTPROTECTED $SYSDIR\PDFImageExtractorShellExt.dll


${EndIf}  

 ExecWait "$INSTDIR\${MUI_FILE}.exe /uninstall"  

 ;nsExec::Exec "$INSTDIR\net_updater32.exe --uninstall win_freepdfimageextractor.4dotssoftware.com" 
 
;Delete Files 
  RMDir /r "$INSTDIR\*.*"    

;Remove the installation directory
;  RMDir "$INSTDIR\de-DE"
  RMDir "$INSTDIR"

;Delete Start Menu Shortcuts
  Delete "$DESKTOP\${PRODUCT_SHORTCUT}.lnk"

  Delete "$SMPROGRAMS\${PRODUCT_SHORTCUT}\*.*"
  RmDir  "$SMPROGRAMS\${PRODUCT_SHORTCUT}"
 
;Delete Uninstaller And Unistall Registry Entries
  DeleteRegKey HKEY_LOCAL_MACHINE "SOFTWARE\${PRODUCT_SHORTCUT}"
  DeleteRegKey HKEY_LOCAL_MACHINE "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}"  
  DeleteRegKey HKLM "Software\4dots Software\PDF Image Extractor"
  DeleteRegKey HKCU "Software\4dots Software\PDF Image Extractor"

SetShellVarContext current
 RMDir /r "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}\*.*"
 RMDir "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"

SectionEnd

;--------------------------------    
;MessageBox Section

 
;Function that calls a messagebox when installation finished correctly
Function .onInstSuccess
 MessageBox MB_OK "You have successfully installed ${MUI_PRODUCT}. Use the desktop icon to start the program."
 ExecShell "" "http://www.4dots-software.com/free-pdf-image-extractor/how_to_use.php?afterinstall=true&version=${PRODUCT_VERSION}";
FunctionEnd
 
 
Function un.onUninstSuccess
  MessageBox MB_OK "You have successfully uninstalled ${MUI_PRODUCT}."
FunctionEnd

Function .onInit
  InitPluginsDir
  ;File /oname=$PLUGINSDIR\NSISSearchSuggestorPage.ini "NSISSearchSuggestorPage.ini"
  !insertmacro INSTALLOPTIONS_EXTRACT "NSISAdditionalActionsPage.ini"
  
  ;copy translations start
  !insertmacro MUI_LANGDLL_DISPLAY
  ;copy translations end
FunctionEnd

Function myGUIInit
  SetShellVarContext all
  StrCpy $INSTDIR "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"
  StrCpy $ShowExtendedOptions "No"
  ;StrCpy $InstallSearchSuggestor "Yes"


FunctionEnd

; Usage
; Define in your script two constants:
;   DOT_MAJOR "(Major framework version)"
;   DOT_MINOR "{Minor framework version)"
;   DOT_MINOR_MINOR "{Minor framework version - last number after the second dot)"
; 
; Call IsDotNetInstalledAdv
; This function will abort the installation if the required version 
; or higher version of the .NET Framework is not installed.  Place it in
; either your .onInit function or your first install section before 
; other code.
Function IsDotNetInstalledAdv
   Push $0
   Push $1
   Push $2
   Push $3
   Push $4
   Push $5
 
  StrCpy $0 "0"
  StrCpy $1 "SOFTWARE\Microsoft\.NETFramework" ;registry entry to look in.
  StrCpy $2 0
 
  StartEnum:
    ;Enumerate the versions installed.
    EnumRegKey $3 HKLM "$1\policy" $2
 
    ;If we don't find any versions installed, it's not here.
    StrCmp $3 "" noDotNet notEmpty
 
    ;We found something.
    notEmpty:
      ;Find out if the RegKey starts with 'v'.  
      ;If it doesn't, goto the next key.
      StrCpy $4 $3 1 0
      StrCmp $4 "v" +1 goNext
      StrCpy $4 $3 1 1
 
      ;It starts with 'v'.  Now check to see how the installed major version
      ;relates to our required major version.
      ;If it's equal check the minor version, if it's greater, 
      ;we found a good RegKey.
      IntCmp $4 ${DOT_MAJOR} +1 goNext yesDotNetReg
      ;Check the minor version.  If it's equal or greater to our requested 
      ;version then we're good.
      StrCpy $4 $3 1 3
      IntCmp $4 ${DOT_MINOR} +1 goNext yesDotNetReg
 
      ;detect sub-version - e.g. 2.0.50727
      ;takes a value of the registry subkey - it contains the small version number
      EnumRegValue $5 HKLM "$1\policy\$3" 0
 
      IntCmpU $5 ${DOT_MINOR_MINOR} yesDotNetReg goNext yesDotNetReg
 
    goNext:
      ;Go to the next RegKey.
      IntOp $2 $2 + 1
      goto StartEnum
 
  yesDotNetReg: 
    ;Now that we've found a good RegKey, let's make sure it's actually
    ;installed by getting the install path and checking to see if the 
    ;mscorlib.dll exists.
    EnumRegValue $2 HKLM "$1\policy\$3" 0
    ;$2 should equal whatever comes after the major and minor versions 
    ;(ie, v1.1.4322)
    StrCmp $2 "" noDotNet
    ReadRegStr $4 HKLM $1 "InstallRoot"
    ;Hopefully the install root isn't empty.
    StrCmp $4 "" noDotNet
    ;build the actuall directory path to mscorlib.dll.
    StrCpy $4 "$4$3.$2\mscorlib.dll"
    IfFileExists $4 yesDotNet noDotNet
 
  noDotNet:
    ;Nope, something went wrong along the way.  Looks like the 
    ;proper .NET Framework isn't installed.  
 
    ;Uncomment the following line to make this function throw a message box right away 
   MessageBox MB_OK "You must have v${DOT_MAJOR}.${DOT_MINOR}.${DOT_MINOR_MINOR} or greater of the .NET Framework installed.$\n$\nPlease download and install the .NET Redistributable from the Webpage that will open and run ${MUI_FILE}Setup.exe once again !"

  ${If} ${RunningX64}

	ExecShell "open" "http://www.microsoft.com/downloads/details.aspx?FamilyID=b44a0000-acf8-4fa1-affb-40e78d788b00"
  ${Else}

	ExecShell "open" "http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5"
  ${EndIf}  




    Abort
     StrCpy $0 0
     Goto done
 
     yesDotNet:
    ;Everything checks out.  Go on with the rest of the installation.
    StrCpy $0 1
 
   done:
     Pop $4
     Pop $3
     Pop $2
     Pop $1
     Exch $0
 FunctionEnd

Function OptionsPage

  ; Prepare shortcut page with default values
  !insertmacro MUI_HEADER_TEXT "Additional Options" "Please select, whether shortcuts should be created."

  ; Display shortcut page
  !insertmacro INSTALLOPTIONS_DISPLAY_RETURN "NSISAdditionalActionsPage.ini"
  pop $R0 

  ${If} $R0 == "cancel"
    Abort
  ${EndIf} 

  ; Get the selected options

  ReadINIStr $R1 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 2" "State"
  ReadINIStr $R2 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 3" "State"
  ReadINIStr $R3 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 4" "State"

  ${If} $R1 == "1"  
    Call AddStartMenu
  ${EndIf}

  ${If} $R2 == "1"  
   Call AddDesktopShortcut
  ${EndIf}  

  ${If} $R3 == "1"  
   Call IntegrateWindowsExplorer
  ${EndIf}  


FunctionEnd

Function .onGUIEnd
  Delete $INSTDIR\vcredist_x64.exe
  Delete $INSTDIR\vcredist_x86.exe

FunctionEnd

Function OpenWebpageFunction
  ExecShell "" "http://www.4dots-software.com/free-pdf-image-extractor/how_to_use.php?afterinstall=true"
FunctionEnd

;eof

Function DonatePage
   File /oname=$PLUGINSDIR\paypal-donate.bmp "C:\code\Misc\paypal-donate.bmp"
   
   Push $0
   Push $1

   !insertmacro MUI_HEADER_TEXT "Please Donate !" "Your donations are absolutely essential to us !"  
   nsDialogs::Create 1018
   Pop $0
   SetCtlColors $0 "" F0F0F0

   ${NSD_CreateBitmap} 150 50 73 44 ""
   Pop $0
   ${NSD_SetImage} $0 $PLUGINSDIR\\paypal-donate.bmp $1
   Push $1

   ; Register handler for click events
   ${NSD_OnClick} $0 DonateWebpage

   ${NSD_CreateLink} 50 120 100% 12 "Please Donate ! You donations are absolutely essential to us !"
   Pop $0
   ${NSD_OnClick} $0 DonateWebpage     
   
   nsDialogs::Show

   Pop $1
   ${NSD_FreeImage} $1

   Pop $1
   Pop $0 

FunctionEnd
 
Function DonateWebpage
	ExecShell "" "http://www.4dots-software.com/donate.php" 
FunctionEnd

; returns a numeric value on the stack, ranging from 0 to 450, 451, 452 or 460. 0 means nothing found, the other values mean at least that version
Function CheckForDotVersion45Up

  ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" Release

  IntCmp $0 393295 is46 isbelow46 is46

  isbelow46:
  IntCmp $0 379893 is452 isbelow452 is452

  isbelow452:
  IntCmp $0 378675 is451 isbelow451 is451

  isbelow451:
  IntCmp $0 378389 is45 isbelow45 is45

  isbelow45:
  Push 0
  Return

  is46:
  Push 460
  Return

  is452:
  Push 452
  Return

  is451:
  Push 451
  Return

  is45:
  Push 45
  Return

FunctionEnd

;copy translations start
Function un.onInit

  !insertmacro MUI_UNGETLANGUAGE
  
FunctionEnd
;copy translations end
;eof