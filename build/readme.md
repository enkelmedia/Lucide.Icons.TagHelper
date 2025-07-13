# Lucide.Icons.TagHelper

![Lucide Icon Tag Helper Icon](https://raw.githubusercontent.com/enkelmedia/Lucide.Icons.TagHelper/refs/heads/main/build/icon.png)

This [ASP.NET Tag Helper](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro) will use icons from the brilliant [Lucide icon library](https://lucide.dev/icons/) and render them as inline SVG-elements in any modern ASP.NET application.

Use the Tag Helper like this:

```html
<lucide-icon name="smile" />
```

## Getting Started
Before the Tag Helper can be used, you'll have to add the following to your `_ViewImports.cshtml` file:

```
@addTagHelper *, Lucide.Icons.TagHelper
```
Then, add any of the [icons](https://lucide.dev/icons/) by providing the name in the name attribute, like this

```html
<lucide-icon name="pizza" />
```


