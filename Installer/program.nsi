; ------------------------------------------------------------------------------
; PickerTool Installation Script V1.0.0.
; ------------------------------------------------------------------------------
!include "MUI2.nsh"

; ------------------------------------------------------------------------------
; Compiler Settings
; ------------------------------------------------------------------------------
unicode true ; create unicode executable (displays all languages).
outfile "PickerTool Installer (x64).exe"
!define SETUP_PROGRAM_NAME "PickerTool"
name "${SETUP_PROGRAM_NAME}"
!define SETUP_PROGRAM_VERSION "1.0.0.0"
!define /date SETUP_CURRENT_YEAR "%Y"
VIProductVersion "${SETUP_PROGRAM_VERSION}"
VIAddVersionKey "CompanyName" "Henry de Jongh"
VIAddVersionKey "FileVersion" "${SETUP_PROGRAM_VERSION}"
VIAddVersionKey "FileDescription" "${SETUP_PROGRAM_NAME} Installer"
VIAddVersionKey "ProductName" "${SETUP_PROGRAM_NAME}"
VIAddVersionKey "ProductVersion" "${SETUP_PROGRAM_VERSION}"
VIAddVersionKey "LegalCopyright" "Copyright (c) Henry de Jongh 2016 - ${SETUP_CURRENT_YEAR}"
VIAddVersionKey "Comments" "https://00laboratories.com/"
; ------------------------------------------------------------------------------
!define SETUP_UNIQUE_IDENTIFIER "1da0096b-662f-47fd-9355-927ac254191b"
; ------------------------------------------------------------------------------
;!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\win-install.ico"
!define MUI_ICON "..\Resources\color-picker-black.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\win-uninstall.ico"
; ------------------------------------------------------------------------------
!define SETUP_UNINSTALL_REGISTRY_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\{${SETUP_UNIQUE_IDENTIFIER}}"
!define SETUP_RELICON "..\Resources\color-picker-black.ico"
!define SETUP_RELFILE "..\bin\Release"
; ------------------------------------------------------------------------------

; ------------------------------------------------------------------------------
; Welcome Page Settings
; ------------------------------------------------------------------------------
!define MUI_WELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange.bmp"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange-uninstall.bmp"
; ------------------------------------------------------------------------------

; ------------------------------------------------------------------------------
; Installer Components
; ------------------------------------------------------------------------------
!insertmacro MUI_PAGE_WELCOME
;!insertmacro MUI_PAGE_LICENSE "license_file"
!insertmacro MUI_PAGE_COMPONENTS

var INSTDIR1
!define MUI_DIRECTORYPAGE_TEXT_TOP "Setup will install the PickerTool software in the following folder. To install in a different folder, click Browse and select another folder. Click Next to continue."
!define MUI_DIRECTORYPAGE_TEXT_DESTINATION "PickerTool Destination Folder"
!define MUI_DIRECTORYPAGE_VARIABLE $INSTDIR1
!insertmacro MUI_PAGE_DIRECTORY

!insertmacro MUI_PAGE_INSTFILES

!define MUI_FINISHPAGE_RUN
!define MUI_FINISHPAGE_RUN_FUNCTION RunAfterSetup
!insertmacro MUI_PAGE_FINISH
; ------------------------------------------------------------------------------
; Uninstaller Components
; ------------------------------------------------------------------------------
!insertmacro MUI_UNPAGE_WELCOME
;!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH
; ------------------------------------------------------------------------------
!insertmacro MUI_LANGUAGE "English"
; ------------------------------------------------------------------------------

; ------------------------------------------------------------------------------
Function RunAfterSetup
    Exec "$INSTDIR1\PickerTool.exe"
FunctionEnd
; ------------------------------------------------------------------------------

; ------------------------------------------------------------------------------
; [Section] PickerTool
; ------------------------------------------------------------------------------
Section "PickerTool" Section1
    ; store installation directories.
    WriteRegStr HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "InstallationDirectory" $INSTDIR1

    ; create the required directories.
    CreateDirectory $INSTDIR1

    ; install files into the main installation directory.
    SetOutPath $INSTDIR1

    File /oname=Icon.ico "${SETUP_RELICON}"
    File "${SETUP_RELFILE}\PickerTool.exe"

    ; write the uninstall keys for windows.
    WriteRegStr HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "DisplayName" "${SETUP_PROGRAM_NAME}"
    WriteRegStr HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "UninstallString" '"$INSTDIR1\Uninstall.exe"'
    WriteRegStr HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "Publisher" "Henry de Jongh"
    WriteRegStr HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "URLInfoAbout" "https://00laboratories.com/"
    WriteRegStr HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "DisplayVersion" "${SETUP_PROGRAM_VERSION}"
    WriteRegStr HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "DisplayIcon" "$INSTDIR1\Icon.ico"
    WriteRegDWORD HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "NoModify" 1
    WriteRegDWORD HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "NoRepair" 1

    ; create the uninstaller executable.
    WriteUninstaller "$INSTDIR1\Uninstall.exe"
SectionEnd
; ------------------------------------------------------------------------------

; ------------------------------------------------------------------------------
; [Section] Start Menu Shortcut
; ------------------------------------------------------------------------------
Section "Start Menu Shortcut" Section2
    ; create the start menu directory if it doesn't exist.
    CreateDirectory "$SMPROGRAMS\00Laboratories"

    ; create the shortcut for the executable.
    CreateShortcut "$SMPROGRAMS\00Laboratories\PickerTool.lnk" "$INSTDIR1\PickerTool.exe"
SectionEnd
; ------------------------------------------------------------------------------

; ------------------------------------------------------------------------------
; [Section] Desktop Shortcut
; ------------------------------------------------------------------------------
Section "Desktop Shortcut" Section3
    ; create the shortcut for the executable.
    CreateShortcut "$DESKTOP\PickerTool.lnk" "$INSTDIR1\PickerTool.exe"
SectionEnd
; ------------------------------------------------------------------------------

; ------------------------------------------------------------------------------
; Section Descriptions
; ------------------------------------------------------------------------------
langstring DESC_Section1 ${LANG_ENGLISH} "The PickerTool software program that lets you pick any pixel on the screen and get the color in RGB, HEX, HSL and HSV."
langstring DESC_Section2 ${LANG_ENGLISH} "Whether to add a shortcut to the Windows Start Menu."
langstring DESC_Section3 ${LANG_ENGLISH} "Whether to add a shortcut to the Windows Desktop."
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
!insertmacro MUI_DESCRIPTION_TEXT ${Section1} $(DESC_Section1)
!insertmacro MUI_DESCRIPTION_TEXT ${Section2} $(DESC_Section2)
!insertmacro MUI_DESCRIPTION_TEXT ${Section3} $(DESC_Section3)
!insertmacro MUI_FUNCTION_DESCRIPTION_END
; ------------------------------------------------------------------------------

; ------------------------------------------------------------------------------
; [On Initialize] Initialize Setup
; ------------------------------------------------------------------------------
Function .onInit
    ; try to retrieve installation paths from the registry or use the fallback.
    ClearErrors
    ReadRegStr $INSTDIR1 HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "InstallationDirectory"
    ${If} ${Errors}
        StrCpy $INSTDIR1 "$PROGRAMFILES64\00Laboratories\PickerTool"
    ${EndIf}

    ; set section as selected and read-only as mandatory installation option.
    IntOp $0 ${SF_SELECTED} | ${SF_RO}
    SectionSetFlags ${Section1} $0
FunctionEnd

; ------------------------------------------------------------------------------
; [Section] Uninstaller
; ------------------------------------------------------------------------------
Section "Uninstall"
    ; retrieve installation paths from the registry.
    ReadRegStr $INSTDIR1 HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}" "InstallationDirectory"

    ; remove registry keys.
    DeleteRegKey HKLM "${SETUP_UNINSTALL_REGISTRY_KEY}"

    ; remove installation files from the main installation directory.
    Delete "$INSTDIR1\Icon.ico"
    Delete "$INSTDIR1\PickerTool.exe"

    ; remove the start menu shortcut.
    Delete "$SMPROGRAMS\00Laboratories\PickerTool.lnk"

    ; remove the desktop shortcut.
    Delete "$DESKTOP\PickerTool.lnk"

    ; also remove the uninstaller.
    Delete "$INSTDIR1\Uninstall.exe"

    ; try removing the empty directories.
    RMDir "$INSTDIR1"
SectionEnd
