;NSIS Modern User Interface
;Multilingual Example Script
;Written by Joost Verburg

!pragma warning error all

;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

  !define MUI_ICON ".\fpzs\favicon.ico"
;--------------------------------
;General

  ;Properly display all languages (Installer will not work on Windows 95, 98 or ME!)
  Unicode true
  !define PRODUCT_NAME "发票助手"
  !define PRODUCT_VERSION "1.0.0"
  !define PRODUCT_PUBLISHER "上海闪起信息技术有限公司"
  ;Name and file
  Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
  OutFile ".\fpzs\bin\release\fpzs-setup-${PRODUCT_VERSION}.exe"

  BrandingText "${PRODUCT_PUBLISHER}"
  ;Default installation folder
  InstallDir "$PROGRAMFILES\fpzs"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\fpzs" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel user

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

  ;Show all languages, despite user's codepage
  !define MUI_LANGDLL_ALLLANGUAGES

;--------------------------------
;Language Selection Dialog Settings

  ;Remember the installer language
  !define MUI_LANGDLL_REGISTRY_ROOT "HKCU" 
  !define MUI_LANGDLL_REGISTRY_KEY "Software\fpzs" 
  !define MUI_LANGDLL_REGISTRY_VALUENAME "Installer Language"

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  ;!insertmacro MUI_PAGE_LICENSE ".\License.txt"
  ;!insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH
  
  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  ;!insertmacro MUI_UNPAGE_LICENSE ".\License.txt"
  ;!insertmacro MUI_UNPAGE_COMPONENTS
  !insertmacro MUI_UNPAGE_DIRECTORY
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "SimpChinese"

;--------------------------------
;Reserve Files
  
  ;If you are using solid compression, files that are required before
  ;the actual installation should be stored first in the data block,
  ;because this will make your installer start faster.
  
  !insertmacro MUI_RESERVEFILE_LANGDLL

;--------------------------------
;Installer Sections

Section "主程序" SecMain

  SetOutPath "$INSTDIR"
  
  CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk" "$INSTDIR\fpzs.exe"
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\fpzs.exe"
  ;ADD YOUR OWN FILES HERE...
  File ".\fpzs\bin\release\fpzs.exe"
  File ".\fpzs\bin\release\fpzs.exe.config"
  File ".\fpzs\bin\release\fpzslib.dll"
  File ".\fpzs\bin\release\ICSharpCode.SharpZipLib.dll"
  File ".\fpzs\bin\release\NPOI.dll"
  File ".\fpzs\bin\release\NPOI.OOXML.dll"
  File ".\fpzs\bin\release\NPOI.OpenXml4Net.dll"
  File ".\fpzs\bin\release\NPOI.OpenXmlFormats.dll"
  
  ;Store installation folder
  WriteRegStr HKCU "Software\fpzs" "" $INSTDIR
  
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
SectionEnd

;--------------------------------
;Installer Functions

Function .onInit

  !insertmacro MUI_LANGDLL_DISPLAY

FunctionEnd

;--------------------------------
;Descriptions

  ;USE A LANGUAGE STRING IF YOU WANT YOUR DESCRIPTIONS TO BE LANGAUGE SPECIFIC

  ;Assign descriptions to sections
  ;!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
   ; !insertmacro MUI_DESCRIPTION_TEXT ${SecMain} "安装主程序"
  ;!insertmacro MUI_FUNCTION_DESCRIPTION_END

 
;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...
  Delete "$INSTDIR\fpzs.exe"
  Delete "$INSTDIR\fpzs.exe.config"
  Delete "$INSTDIR\fpzslib.dll"
  Delete "$INSTDIR\ICSharpCode.SharpZipLib.dll"
  Delete "$INSTDIR\NPOI.dll"
  Delete "$INSTDIR\NPOI.OOXML.dll"
  Delete "$INSTDIR\NPOI.OpenXml4Net.dll"
  Delete "$INSTDIR\NPOI.OpenXmlFormats.dll"
  Delete "$INSTDIR\Uninstall.exe"

  RMDir "$INSTDIR"

  Delete "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall.lnk"
  Delete "$DESKTOP\${PRODUCT_NAME}.lnk"
  Delete "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk"

  RMDir "$SMPROGRAMS\${PRODUCT_NAME}"
  
  DeleteRegKey /ifempty HKCU "Software\fpzs"

SectionEnd

;--------------------------------
;Uninstaller Functions

Function un.onInit

  !insertmacro MUI_UNGETLANGUAGE
  
FunctionEnd