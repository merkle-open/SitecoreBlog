# Sitecore Blog Guidelines

## How the blog works

GitHub Pages is powered by the static site generator [Jekyll](https://jekyllrb.com/). Every change/push you do in the [docs](.) folder triggers a new build and deployment of the site.

Check out the [official page](https://pages.github.com/versions/) which lists all the tools and versions being used during that build process.

## How to create a new post

Jekyll allows you to write blog posts in either HTML or Markdown. If you are not sure on which one to use, then the recommendation would be to use Markdown as it is easy to use and gets transformed into standardized HTML automatically. If you want to build a more advanced frontend in your post then HTML is the better choice. However, it's really up to you. In the end, you as an author are responsible that your post looks as good as possible.

If you decided on the file format then copy one of the following predefined templates:

- [Markdown](_drafts/YYYY-MM-DD-name-of-post.md)
- [HTML](_drafts/YYYY-MM-DD-name-of-post.html)

Replace the "YYYY-MM-DD" part with the intended publish date (e.g. 2021-01-28). Then replace the "name-of-post" part with the intended name of the post. Please keep in mind that this name will be part of the URL of your post. Therefore, for best SEO results follow those simple guidelines:

- Always use dashes (-) instead of blanks ( )
- Incorporate the main keywords which you want the post to be found for in search engines
- Just by reading this name, the visitor should get a good understanding of what the post is about
- Keep it as short as possible

Next up, open the created file and edit the following [Front Matter](https://jekyllrb.com/docs/front-matter/) of the file:

- title
- date
- categories: Use one or two of the [existing categories](https://sitecore.namics.com/categories.json). If you really can't find an appropriate category for your post there then introduce a new one in your file. It will be automatically added to the list of exiisting categories.
- tags: Add as many tags as you want. They should additionally describe the contents of your post (e.g. used framework or tools). As a source of inspiration you can also have a look at the [tags](https://sitecore.namics.com/tags.json) that other authors have defined previously.
- author: Use a combination of your first name's first character and your last name here (e.g. Fabian Geiger -> fgeiger)

Everything below the Front Matter belongs to the contents of your post. If you are ready to publish your post then move the file from the [_drafts](_drafts) to the [_posts](_posts) folder. Create a commit with a meaningful message and push to GitHub. After a maximum of 15 minutes, your post should be listed on the home page of the blog.

## Tips and tricks on editing posts

### Images and files

Put images or single files which you want to share in blog posts into the [files](files) folder. For more complex file structures (e.g. a whole Visual Studio project), put those into the [main repository](..) directly.

### Templating

Jekyll uses the [Liquid](https://jekyllrb.com/docs/liquid/) templating language to process templates. This gives you the possibility to apply simple logic to your posts if needed. Liquid is available in both HTML and Markdown files. There are very useful filters and tags which let you easily embed code or create internal links.

#### Updating CSS

You can update the default `minima` theme: <https://github.com/jekyll/minima#customizing-templates>.

#### Code snippets

For embedding code in blog posts you have two possibilities. You can either use the Liquid-tag [`highlight`](https://jekyllrb.com/docs/liquid/tags/) which automatically converts code into a nicely highlighted HTML structure during build. The other possibility would be to embed a gist into the post by using the Liquid-tag [`gist`](https://github.com/jekyll/jekyll-gist). Gists are probably more suited to complex code which you want to maintain over a longer time period as they have a version history.

## How to create your own author page

If you are interested in having your personal author page on the blog, then please follow the following steps:

- Copy one of the existing pages in the [_authors](_authors) folder. Use a combination of your first name's first character and your last name as file name (e.g. Fabian Geiger -> fgeiger)
- Edit the Front Matter
- Optionally, you can add personal information about yourself below the Front Matter

## How to test your changes locally

[Install Ruby and Jekyll](https://jekyllrb.com/docs/installation/). For Windows, the easiest way to install Ruby and Jekyll is by using the [RubyInstaller](https://jekyllrb.com/docs/installation/windows/). In order to mimic the build process of GitHub as good as possible on your local machine use the same (or most similar) version of Jekyll as listed [here](https://pages.github.com/versions/).

Open the command line and navigate to the [docs](.) folder. Execute the following command: `bundle exec jekyll serve`

### Working with drafts

Posts that reside in the [_drafts](_drafts) folder won't get published automatically. However, you can preview your site with drafts locally by adding the `--drafts` parameter to the serve command: `bundle exec jekyll serve --drafts`