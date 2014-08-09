@echo off
REM by Bradley Van Aardt
REM theminidriver@gmail.com
REM Expects the folder name of the project to delete bin files from. 
REM if you want not delete a directory, then place an empty file with the name "_dont_delete_squeaky_clean" and the directory will not be deleted

echo ----------------------------------------------------
echo cleaning dlls from Project %1 ...
echo ----------------------------------------------------

echo deleting Bin Directory...
if exist %1\bin\_dont_delete_squeaky_clean (
    echo skipped deleting directory. Dont delete file found!
) else (
    rd %1\bin /s/q
)

echo deleting Obj Directory...
rd %1\obj /s/q

echo deleting csx Directory...
rd %1\csx /s/q

echo.
echo Finished cleaning files from %1
echo.
echo.
