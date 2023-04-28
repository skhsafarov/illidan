git checkout main
git add *
git commit -m "saved main branch"
git push


# удалить всё кроме папки с названием ".git"
Remove-Item -Path .published/illidan/* -Recurse -Exclude .git
Remove-Item -Path illidan_Client/bin/Release/net6.0/Published/* -Recurse -Exclude .git
dotnet publish illidan_Client/illidan_Client.csproj -c Release -o illidan_Client/bin/Release/net6.0/Published
move illidan_Client/bin/Release/net6.0/Published/wwwroot/* .published/illidan
cd .published/illidan
# удалить файл "manifest.json"
Remove-Item -Path manifest.json
# переименовать файл "release.json" в "manifest.json"
Rename-Item -Path release.json -NewName manifest.json
# удалить файл "index.html"
Remove-Item -Path index.html
# создать копию файла "404.html" с названием "index.html"
Copy-Item -Path "404.html" -Destination "index.html"
git checkout gh-pages
git add *
git commit -m "published gh-pages branch"
git push
