git checkout master
git add *
git commit -m "saved master branch"
git push


# удалить всё кроме папки с названием ".git"
Remove-Item -Path .published/illidan/* -Recurse -Exclude .git




#move bin/Release/net6.0/illidan/.git bin/Release/net6.0
#remove-item -path bin/Release/net6.0/illidan/* -recurse
#move bin/Release/net6.0/.git bin/Release/net6.0/illidan
#remove-item -path bin/Release/net6.0/Published/* -recurse
#dotnet publish -c Release -o bin/Release/net6.0/Published
#cd bin/Release/net6.0/illidan
#move ../Published/wwwroot/*
#git checkout gh-pages
#git add *
#git commit -m "published gh-pages branch"
#git push