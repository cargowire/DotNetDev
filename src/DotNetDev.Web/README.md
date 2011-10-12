# DotNetDev - 'Supporting Code'

This isn't really part of the demo but by all means take a look! 

* CodeViewer Module - Reads a code file from disk (that wouldn't normally be served by IIS) and serves it within an html wrapper containing syntax highlighting
* EmbeddedResourceModule - Responses to specially formatted resource requests that pull content from within the compiled dll.  In this case the css and js required by the clientside syntax highlighting
* [Alex Gorbatchev's Syntax Highlighter](https://github.com/alexgorbatchev/SyntaxHighlighter) s embedded for ease of use/deployment with the dll for the CodeViewer