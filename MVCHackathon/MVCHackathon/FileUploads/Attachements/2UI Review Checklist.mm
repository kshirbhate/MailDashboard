<map version="1.0.1">
<!-- To view this file, download free mind mapping software FreeMind from http://freemind.sourceforge.net -->
<node CREATED="1504006312981" ID="ID_84193717" MODIFIED="1504013892256" STYLE="bubble" TEXT="UI Review Checklist">
<node CREATED="1504006322491" ID="ID_1340499622" MODIFIED="1504016132303" POSITION="right" STYLE="bubble" TEXT="Visuals">
<node CREATED="1504006414374" ID="ID_684021579" MODIFIED="1504016177659" STYLE="bubble" TEXT="UI elements should  render exactly same as in design mockups">
<node CREATED="1504006506244" ID="ID_1298656894" MODIFIED="1504013814348" STYLE="bubble" TEXT="Check for extra paddings">
<node CREATED="1504010898738" ID="ID_1906389842" MODIFIED="1504013814348" STYLE="bubble" TEXT="This might change div&apos;s height and width"/>
</node>
<node CREATED="1504006562370" ID="ID_470129912" MODIFIED="1504013814348" STYLE="bubble" TEXT="Check for extra margins">
<node CREATED="1504010898738" ID="ID_1288756448" MODIFIED="1504013814348" STYLE="bubble" TEXT="This might give you white space in between divs."/>
</node>
<node CREATED="1504010742115" ID="ID_512509224" MODIFIED="1504013814348" STYLE="bubble" TEXT="Check for horinzontal scrollbar.">
<node CREATED="1504010972172" ID="ID_428046775" MODIFIED="1504013814348" STYLE="bubble" TEXT="This comes because there might be a width, padding or margin that is going outside to parent div."/>
</node>
<node CREATED="1504006569923" ID="ID_1769522939" MODIFIED="1504013814348" STYLE="bubble" TEXT="Check for Typography elements">
<node CREATED="1504011880070" ID="ID_689931380" MODIFIED="1504013814348" STYLE="bubble" TEXT="Check for applied styles to elements, this should be as per markups">
<node CREATED="1504006695014" ID="ID_509147640" MODIFIED="1504013814348" STYLE="bubble" TEXT="Colors"/>
<node CREATED="1504006699613" ID="ID_1826319308" MODIFIED="1504013814348" STYLE="bubble" TEXT="Font-weights"/>
<node CREATED="1504006709862" ID="ID_330754234" MODIFIED="1504013814348" STYLE="bubble" TEXT="size"/>
<node CREATED="1504006718885" ID="ID_1702786282" MODIFIED="1504013814348" STYLE="bubble" TEXT="height"/>
<node CREATED="1504006728663" ID="ID_490891011" MODIFIED="1504013814348" STYLE="bubble" TEXT="width"/>
</node>
</node>
<node CREATED="1504012898795" ID="ID_1440468935" MODIFIED="1504013814348" STYLE="bubble" TEXT="Check for overlay (popovers, modals, tooltips)">
<node CREATED="1504012978411" ID="ID_1420504709" MODIFIED="1504013814348" STYLE="bubble" TEXT="when checking on mobile, width should not go outside viewport for overlays."/>
</node>
<node CREATED="1504008573840" ID="ID_1313098801" MODIFIED="1504013814348" STYLE="bubble" TEXT="If using parent child elements, then calculate padding, margins, width or height properly so that parent div will have proper style in terms of padding, margins, width or height."/>
<node CREATED="1504008331988" ID="ID_876259523" MODIFIED="1504013814349" STYLE="bubble" TEXT="Check whether same classes are not being rendered in style tab of inspect element.">
<node CREATED="1504012013917" ID="ID_1374353693" MODIFIED="1504013814350" STYLE="bubble" TEXT="This happens because of importing same css file in components which are again rendered in parent component."/>
</node>
<node CREATED="1504008412352" ID="ID_1961826436" MODIFIED="1504013814351" STYLE="bubble" TEXT="Try to avoid inline styles, instead create feature level styles and override">
<node CREATED="1504012179403" ID="ID_185673064" MODIFIED="1504013814351" STYLE="bubble" TEXT="If you want to override a style then you should write class specific to that element and put that in feature level css file."/>
</node>
<node CREATED="1504009539822" ID="ID_1126674016" MODIFIED="1504013814352" STYLE="bubble" TEXT="Give id&apos;s to each elements and they should be unique">
<node CREATED="1504009688463" ID="ID_963493624" MODIFIED="1504013814352" STYLE="bubble" TEXT="You can apply styles by using ids. but you should give styles to ids only wherever required. because id has more weightage than class.."/>
</node>
<node CREATED="1504006766402" ID="ID_1396193830" MODIFIED="1504013814353" STYLE="bubble" TEXT="When using third party css library look into this points">
<node CREATED="1504007068107" ID="ID_981310778" MODIFIED="1504013814353" STYLE="bubble" TEXT="whether it overrides your style classes"/>
<node CREATED="1504008171107" ID="ID_1748223230" MODIFIED="1504013814353" STYLE="bubble" TEXT="When using row, col classes check for paddings and margins."/>
</node>
</node>
<node CREATED="1504013947571" ID="ID_841767942" MODIFIED="1504013963643" TEXT="remove console.logs statements from code."/>
<node CREATED="1504007718093" ID="ID_209045710" MODIFIED="1504013814353" STYLE="bubble" TEXT="This above steps can be done on Chrome, Mozilla, IE for Desktop, Mobile and Tablet also"/>
</node>
<node CREATED="1504008243096" ID="ID_1456072329" MODIFIED="1504013814353" POSITION="right" STYLE="bubble" TEXT="Code">
<node CREATED="1504008249713" ID="ID_970070524" MODIFIED="1504069329461" STYLE="bubble" TEXT="UI Styles">
<node CREATED="1504069334135" ID="ID_1935715318" MODIFIED="1504069426774" TEXT="When writing style classes, set your browsers on minimum boundaries">
<node CREATED="1504069428089" ID="ID_730021075" MODIFIED="1504069520049" TEXT="Set 320 for mobile"/>
<node CREATED="1504069521213" ID="ID_1337272240" MODIFIED="1504069532250" TEXT="Set 768 for tablet"/>
<node CREATED="1504069532614" ID="ID_1081380094" MODIFIED="1504069541626" TEXT="Set 992 for desktop"/>
</node>
<node CREATED="1504008260450" ID="ID_1403411675" MODIFIED="1504013814353" STYLE="bubble" TEXT="Consistent naming conventions are used"/>
<node CREATED="1504012566854" ID="ID_1701044227" MODIFIED="1504013814353" STYLE="bubble" TEXT="CSS validates against the W3C validator"/>
<node CREATED="1504012616616" ID="ID_517235975" MODIFIED="1504013814353" STYLE="bubble" TEXT="CSS selectors are only as specific as they need to be; grouped logically"/>
<node CREATED="1504012680274" ID="ID_376268178" MODIFIED="1504013814353" STYLE="bubble" TEXT="Events and styles applied to :hover are also applied to :focus"/>
</node>
<node CREATED="1504008256056" FOLDED="true" ID="ID_1645312856" MODIFIED="1504016163444" STYLE="bubble" TEXT="UI Code">
<node CREATED="1504012717261" ID="ID_1626960833" MODIFIED="1504013814354" STYLE="bubble" TEXT="Code does not contain inline style attributes"/>
<node CREATED="1504012719589" ID="ID_939285636" MODIFIED="1504013814354" STYLE="bubble" TEXT="Code does not contain deprecated elements &amp; attributes"/>
<node CREATED="1504012735260" ID="ID_1515320669" MODIFIED="1504013814354" STYLE="bubble" TEXT="Tags and attributes are lowercase (For CSS)"/>
<node CREATED="1504012760077" ID="ID_1110556589" MODIFIED="1504013814354" STYLE="bubble" TEXT="Tags are closed and nested properly"/>
<node CREATED="1504012777654" ID="ID_180181247" MODIFIED="1504013814354" STYLE="bubble" TEXT="Tables are only used to display tabular data"/>
<node CREATED="1504012786432" ID="ID_1547982814" MODIFIED="1504013814354" STYLE="bubble" TEXT="Element IDs are unique"/>
<node CREATED="1504014098450" ID="ID_1499463012" MODIFIED="1504014115537" TEXT="Add Comments wherever required."/>
<node CREATED="1504014116452" ID="ID_1103374582" MODIFIED="1504014156330" TEXT="Their should not be any garbage code."/>
<node CREATED="1504014158118" ID="ID_1071979564" MODIFIED="1504014181660" TEXT="Import only those third party libraries which are required."/>
<node CREATED="1504006336625" ID="ID_914009879" MODIFIED="1504013814347" STYLE="bubble" TEXT="Code should run with 0 errors in console."/>
<node CREATED="1504006382274" ID="ID_1700730368" MODIFIED="1504013814347" STYLE="bubble" TEXT="Code should run with 0 warnings in console"/>
</node>
<node CREATED="1504014075202" ID="ID_1054393381" MODIFIED="1504014077494" TEXT="React Code"/>
</node>
</node>
</map>
