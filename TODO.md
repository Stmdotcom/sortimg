# TODO
- Cleanup; Do a full basic cleanup to correct obvious issues. There should be 0 Messages in error list when done
- Explain what auto matching is (Use a ? icon thing)
- Allow setting for how many images are loaded at once in preview (Not sure if useful...)
- Selected picture logic is too complex, should only be based off images in `selectedImageViewers` the first image should ALWAYS be one shown. Can simplify logic around `FixActiveSelection` and `SetPicture`
- Move logic into classes. There is too much logic still in `Main.cs` should only deal with form logic