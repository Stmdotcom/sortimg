# TODO
- Cleanup; Do a full basic cleanup to correct obvious issues. There should be 0 Messages in error list when done
- Logging should be enabled in settings
- Sort type for images should be a radio button on the folder setup dialog (Then can remove dialog togeather with change above)
- Add auto matching setting to the folder add dialog. Explain what auto matching is (Use a ? icon thing)
- Allow setting for how many images are loaded at once in preview (Not sure if useful...)
- Selected picture logic is too complex, should only be based off images in `selectedImageViewers` the first image should ALWAYS be one shown. Can simplify logic around `FixActiveSelection` and `SetPicture`
- Move logic into classes. There is too much logic still in `Main.cs` should only deal with form logic