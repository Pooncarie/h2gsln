open Giraffe.ViewEngine
open Giraffe.ViewEngine.Accessibility
open Giraffe.Deprecated

let google = // www.google.com
 html [_itemscope ""; _itemtype "http://schema.org/WebPage"; _lang "en-AU"]  [
  head [] [
    meta [_content "text/html; charset=UTF-8"; _httpEquiv "Content-Type"]
    meta [_content "/images/branding/googleg/1x/googleg_standard_color_128dp.png"; _itemprop "image"]
    title [] [
      str "Google"
    ]
    script [_nonce "S1a8Y4DEp8RzC2L4YUvk6A"]  [
      rawText """(function(){var _g={kEI:'zh0waP-UM-bc2roPn9-S-AM',kEXPI:'0,202791,49,14,2,609859,2887616,1053,448529,90132,48791,30022,16105,344796,219811,27508,42725,5230292,11389,365,32768569,4043709,25228681,138268,14125,65160,6750,23879,9138,4600,328,6225,54190,19,9956,15048,8221,7411,30379,696,155,11654,2,15827,50106,4105,353,18880,3122,3,2745,3100,4614,5773,4311,10610,1731,10960,16524,3261,1534,7,1449,35,6283,1,2491,2,320,69,7738,569,11538,658,1932,3093,2,3602,8523,3996,2,626,4625,1515,1209,858,1450,1175,2955,1132,1607,839,5,3558,2,1,2,2,2,3,2316,649,2153,1564,498,9,4,2047,1511,1253,334,601,3,984,486,3874,550,744,444,1043,1928,627,1,219,394,626,1,747,2530,186,2,78,126,1090,132,1091,537,4,659,471,7,152,327,891,365,198,912,158,1220,358,4809,43,847,253,119,363,1281,283,2347,819,436,1020,1,552,4,475,949,644,230,289,457,1026,86,17,1,3,1,341,6,2,433,787,1538,1,645,357,302,679,329,432,96,45,131,57,18,315,316,373,533,14,6,152,522,7,154,5,5,374,316,1024,811,1072,7,188,212,366,51,511,155,86,1302,699,71,184,774,137,826,3,2,2,2,17,3,130,595,586,218,39,3,786,549,165,721,68,3,104,668,23,286,264,3,3,812,60,1,90,2,31,17,4,112,66,446,251,83,206,38,561,154,1,5,122,460,2,178,470,521,786,1270,402,68,200,2678,20862936,413679,4,2397,5,2992,4,2960,3,1308,2610,3,97,27,288,15,821,1508,206,652,956,2,1462,11,49,214,380,24,32,298,276,6025007,2473307,138911',kBL:'K8Wi',kOPI:89978449};(function(){var a;((a=window.google)==null?0:a.stvsc)?google.kEI=_g.kEI:window.google=_g;}).call(this);})();(function(){google.sn='webhp';google.kHL='en-AU';})();(function(){
var g=this||self;function k(){return window.google&&window.google.kOPI||null};var l,m=[];function n(a){for(var b;a&&(!a.getAttribute||!(b=a.getAttribute("eid")));)a=a.parentNode;return b||l}function p(a){for(var b=null;a&&(!a.getAttribute||!(b=a.getAttribute("leid")));)a=a.parentNode;return b}function q(a){/^http:/i.test(a)&&window.location.protocol==="https:"&&(google.ml&&google.ml(Error("a"),!1,{src:a,glmm:1}),a="");return a}
function r(a,b,d,c,h){var e="";b.search("&ei=")===-1&&(e="&ei="+n(c),b.search("&lei=")===-1&&(c=p(c))&&(e+="&lei="+c));var f=b.search("&cshid=")===-1&&a!=="slh";c="&zx="+Date.now().toString();g._cshid&&f&&(c+="&cshid="+g._cshid);(d=d())&&(c+="&opi="+d);return"/"+(h||"gen_204")+"?atyp=i&ct="+String(a)+"&cad="+(b+e+c)};l=google.kEI;google.getEI=n;google.getLEI=p;google.ml=function(){return null};google.log=function(a,b,d,c,h,e){e=e===void 0?k:e;d||(d=r(a,b,e,c,h));if(d=q(d)){a=new Image;var f=m.length;m[f]=a;a.onerror=a.onload=a.onabort=function(){delete m[f]};a.src=d}};google.logUrl=function(a,b){b=b===void 0?k:b;return r("",a,b)};}).call(this);(function(){google.y={};google.sy=[];var d;(d=google).x||(d.x=function(a,b){if(a)var c=a.id;else{do c=Math.random();while(google.y[c])}google.y[c]=[a,b];return!1});var e;(e=google).sx||(e.sx=function(a){google.sy.push(a)});google.lm=[];var f;(f=google).plm||(f.plm=function(a){google.lm.push.apply(google.lm,a)});google.lq=[];var g;(g=google).load||(g.load=function(a,b,c){google.lq.push([[a],b,c])});var h;(h=google).loadAll||(h.loadAll=function(a,b){google.lq.push([a,b])});google.bx=!1;var k;(k=google).lx||(k.lx=function(){});var l=[],m;(m=google).fce||(m.fce=function(a,b,c,n){l.push([a,b,c,n])});google.qce=l;}).call(this);google.f={};(function(){
document.documentElement.addEventListener("submit",function(b){var a;if(a=b.target){var c=a.getAttribute("data-submitfalse");a=c==="1"||c==="q"&&!a.elements.q.value?!0:!1}else a=!1;a&&(b.preventDefault(),b.stopPropagation())},!0);document.documentElement.addEventListener("click",function(b){var a;a:{for(a=b.target;a&&a!==document.documentElement;a=a.parentElement)if(a.tagName==="A"){a=a.getAttribute("data-nohref")==="1";break a}a=!1}a&&b.preventDefault()},!0);}).call(this);"""
    ]
    style [] [
      str "#gbar,#guser{font-size:13px;padding-top:1px !important;}#gbar{height:22px}#guser{padding-bottom:7px !important;text-align:right}.gbh,.gbd{border-top:1px solid #c9d7f1;font-size:1px}.gbh{height:0;position:absolute;top:24px;width:100%}@media all{.gb1{height:22px;margin-right:.5em;vertical-align:top}#gbar{float:left}}a.gb1,a.gb4{text-decoration:underline !important}a.gb1,a.gb4{color:#00c !important}.gbi .gb4{color:#dd8e27 !important}.gbf .gb4{color:#900 !important}"
    ]
    style [] [
      str "body,td,a,p,.h{font-family:sans-serif}body{margin:0;overflow-y:scroll}#gog{padding:3px 8px 0}td{line-height:.8em}.gac_m td{line-height:17px}form{margin-bottom:20px}.h{color:#1967d2}em{font-weight:bold;font-style:normal}.lst{height:25px;width:496px}.gsfi,.lst{font:18px sans-serif}.gsfs{font:17px sans-serif}.ds{display:inline-box;display:inline-block;margin:3px 0 4px;margin-left:4px}input{font-family:inherit}body{background:#fff;color:#000}input{-moz-box-sizing:content-box}a{color:#681da8;text-decoration:none}a:hover,a:active{text-decoration:underline}.fl a{color:#1967d2}a:visited{color:#681da8}.sblc{padding-top:5px}.sblc a{display:block;margin:2px 0;margin-left:13px;font-size:11px}.lsbb{background:#f8f9fa;border:solid 1px;border-color:#dadce0 #70757a #70757a #dadce0;height:30px}.lsbb{display:block}#WqQANb a{display:inline-block;margin:0 12px}.lsb{background:url(/images/nav_logo229.png) 0 -261px repeat-x;color:#000;border:none;cursor:pointer;height:30px;margin:0;outline:0;font:15px sans-serif;vertical-align:top}.lsb:active{background:#dadce0}.lst:focus{outline:none}"
    ]
    script [_nonce "S1a8Y4DEp8RzC2L4YUvk6A"]  [
      rawText """(function(){window.google.erd={jsr:1,bv:2222,de:true,dpf:'6flVvL9N66lfdCwG6FCZRhbBC4teAFSfANkHf_2EePg'};
var g=this||self;var k,l=(k=g.mei)!=null?k:1,m,p=(m=g.diel)!=null?m:0,q,r=(q=g.sdo)!=null?q:!0,t=0,u,w=google.erd,x=w.jsr;google.ml=function(a,b,d,n,e){e=e===void 0?2:e;b&&(u=a&&a.message);d===void 0&&(d={});d.cad="ple_"+google.ple+".aple_"+google.aple;if(google.dl)return google.dl(a,e,d,!0),null;b=d;if(x<0){window.console&&console.error(a,b);if(x===-2)throw a;b=!1}else b=!a||!a.message||a.message==="Error loading script"||t>=l&&!n?!1:!0;if(!b)return null;t++;d=d||{};b=encodeURIComponent;var c="/gen_204?atyp=i&ei="+b(google.kEI);google.kEXPI&&(c+="&jexpid="+b(google.kEXPI));c+="&srcpg="+b(google.sn)+"&jsr="+b(w.jsr)+
"&bver="+b(w.bv);w.dpf&&(c+="&dpf="+b(w.dpf));var f=a.lineNumber;f!==void 0&&(c+="&line="+f);var h=a.fileName;h&&(h.indexOf("-extension:/")>0&&(e=3),c+="&script="+b(h),f&&h===window.location.href&&(f=document.documentElement.outerHTML.split("\n")[f],c+="&cad="+b(f?f.substring(0,300):"No script found.")));google.ple&&google.ple===1&&(e=2);c+="&jsel="+e;for(var v in d)c+="&",c+=b(v),c+="=",c+=b(d[v]);c=c+"&emsg="+b(a.name+": "+a.message);c=c+"&jsst="+b(a.stack||"N/A");c.length>=12288&&(c=c.substr(0,12288));a=c;n||google.log(0,"",a);return a};window.onerror=function(a,b,d,n,e){u!==a&&(a=e instanceof Error?e:Error(a),d===void 0||"lineNumber"in a||(a.lineNumber=d),b===void 0||"fileName"in a||(a.fileName=b),google.ml(a,!1,void 0,!1,a.name==="SyntaxError"||a.message.substring(0,11)==="SyntaxError"||a.message.indexOf("Script error")!==-1?3:p));u=null;r&&t>=l&&(window.onerror=null)};})();"""
    ]
  ]
  body [_bgcolor "#fff"]  [
    script [_nonce "S1a8Y4DEp8RzC2L4YUvk6A"]  [
      rawText """(function(){var src='/images/nav_logo229.png';var iesg=false;document.body.onload = function(){window.n && window.n();if (document.images){new Image().src=src;}
if (!iesg){document.f&&document.f.q.focus();document.gbqf&&document.gbqf.q.focus();}
}
})();"""
    ]
    div [_id "mngb"]  [
      div [_id "gbar"]  [
        nobr [] [
          b [_class "gb1"]  [
            str "Search"
          ]
          a [_class "gb1"; _href "https://www.google.com/imghp?hl=en&tab=wi"]  [
            str "Images"
          ]
          a [_class "gb1"; _href "https://maps.google.com.au/maps?hl=en&tab=wl"]  [
            str "Maps"
          ]
          a [_class "gb1"; _href "https://play.google.com/?hl=en&tab=w8"]  [
            str "Play"
          ]
          a [_class "gb1"; _href "https://www.youtube.com/?tab=w1"]  [
            str "YouTube"
          ]
          a [_class "gb1"; _href "https://news.google.com/?tab=wn"]  [
            str "News"
          ]
          a [_class "gb1"; _href "https://mail.google.com/mail/?tab=wm"]  [
            str "Gmail"
          ]
          a [_class "gb1"; _href "https://drive.google.com/?tab=wo"]  [
            str "Drive"
          ]
          a [_class "gb1"; _style "text-decoration:none"; _href "https://www.google.com.au/intl/en/about/products?tab=wh"]  [
            u [] [
              str "More"
            ]
            str "&raquo;"
          ]
        ]
      ]
      div [_id "guser"; _width "100%"]  [
        nobr [] [
          span [_id "gbn"; _class "gbi"] []
          span [_id "gbf"; _class "gbf"] []
          span [_id "gbe"] []
          a [_href "http://www.google.com.au/history/optout?hl=en"; _class "gb4"]  [
            str "Web History"
          ]
          str "|"
          a [_href "/preferences?hl=en"; _class "gb4"]  [
            str "Settings"
          ]
          str "|"
          a [_target "_top"; _id "gb_70"; _href "https://accounts.google.com/ServiceLogin?hl=en&passive=true&continue=https://www.google.com/&ec=GAZAAQ"; _class "gb4"]  [
            str "Sign in"
          ]
        ]
      ]
      div [_class "gbh"; _style "left:0"] []
      div [_class "gbh"; _style "right:0"] []
    ]
    center [] [
      br [_clear "all"; _id "lgpd"]
      div [_id "XjhHGf"]  [
        img [_alt "Google"; _height "92"; _src "/images/branding/googlelogo/1x/googlelogo_white_background_color_272x92dp.png"; _style "padding:28px 0 14px"; _width "272"; _id "hplogo"]
        br []
        br []
      ]
      form [_action "/search"; _name "f"]  [
        table [_cellpadding "0"; _cellspacing "0"]  [
          tr [_valign "top"]  [
            td [_width "25%"]  [
              str "&nbsp;"
            ]
            td [_align "center"; _nowrap ""]  [
              input [_value "en-AU"; _name "hl"; _type "hidden"]
              input [_name "source"; _type "hidden"; _value "hp"]
              input [_name "biw"; _type "hidden"]
              input [_name "bih"; _type "hidden"]
              div [_class "ds"; _style "height:32px;margin:4px 0"]  [
                input [_class "lst"; _style "margin:0;padding:5px 8px 0 6px;vertical-align:top;color:#000"; _autocomplete "off"; _value ""; _title "Google Search"; _maxlength "2048"; _name "q"; _size "57"]
              ]
              br [_style "line-height:0"]
              span [_class "ds"]  [
                span [_class "lsbb"]  [
                  input [_class "lsb"; _value "Google Search"; _name "btnG"; _type "submit"]
                ]
              ]
              span [_class "ds"]  [
                span [_class "lsbb"]  [
                  input [_class "lsb"; _id "tsuid_zh0waP-UM-bc2roPn9-S-AM_1"; _value "I'm Feeling Lucky"; _name "btnI"; _type "submit"]
                  script [_nonce "S1a8Y4DEp8RzC2L4YUvk6A"]  [
                    rawText """(function(){var id='tsuid_zh0waP-UM-bc2roPn9-S-AM_1';document.getElementById(id).onclick = function(){if (this.form.q.value){this.checked = 1;if (this.form.iflsig)this.form.iflsig.disabled = false;}
else top.location='/doodles/';};})();"""
                  ]
                  input [_value "ACkRmUkAAAAAaDAr3kUQAfmXUzMczO7S3L0CvIUye8xM"; _name "iflsig"; _type "hidden"]
                ]
              ]
            ]
            td [_class "fl sblc"; _align "left"; _nowrap ""; _width "25%"]  [
              a [_href "/advanced_search?hl=en-AU&amp;authuser=0"]  [
                str "Advanced search"
              ]
            ]
          ]
        ]
        input [_id "gbv"; _name "gbv"; _type "hidden"; _value "1"]
        script [_nonce "S1a8Y4DEp8RzC2L4YUvk6A"]  [
          rawText """(function(){var a,b="1";if(document&&document.getElementById)if(typeof XMLHttpRequest!="undefined")b="2";else if(typeof ActiveXObject!="undefined"){var c,d,e=["MSXML2.XMLHTTP.6.0","MSXML2.XMLHTTP.3.0","MSXML2.XMLHTTP","Microsoft.XMLHTTP"];for(c=0;d=e[c++];)try{new ActiveXObject(d),b="2"}catch(h){}}a=b;if(a=="2"&&location.search.indexOf("&gbv=2")==-1){var f=google.gbvu,g=document.getElementById("gbv");g&&(g.value=a);f&&window.setTimeout(function(){location.href=f},0)};}).call(this);"""
        ]
      ]
      div [_style "font-size:83%;min-height:3.5em"]  [
        br []
      ]
      span [_id "footer"]  [
        div [_style "font-size:10pt"]  [
          div [_style "margin:19px auto;text-align:center"; _id "WqQANb"]  [
            a [_href "/intl/en/ads/"]  [
              str "Advertising"
            ]
            a [_href "/services/"]  [
              str "Business Solutions"
            ]
            a [_href "/intl/en/about.html"]  [
              str "About Google"
            ]
            a [_href "https://www.google.com/setprefdomain?prefdom=AU&amp;prev=https://www.google.com.au/&amp;sig=K_67CQEUywCqU7rhu_Sq78lFHmG6w%3D"]  [
              str "Google.com.au"
            ]
          ]
        ]
        p [_style "font-size:8pt;color:#5e5e5e"]  [
          str "&copy; 2025 -"
          a [_href "/intl/en/policies/privacy/"]  [
            str "Privacy"
          ]
          str "-"
          a [_href "/intl/en/policies/terms/"]  [
            str "Terms"
          ]
        ]
      ]
    ]
    script [_nonce "S1a8Y4DEp8RzC2L4YUvk6A"]  [
      rawText """(function(){window.google.cdo={height:757,width:1440};(function(){var a=window.innerWidth,b=window.innerHeight;if(!a||!b){var c=window.document,d=c.compatMode=="CSS1Compat"?c.documentElement:c.body;a=d.clientWidth;b=d.clientHeight}if(a&&b&&(a!=google.cdo.width||b!=google.cdo.height)){var e=google,f=e.log,g="/client_204?&atyp=i&biw="+a+"&bih="+b+"&ei="+google.kEI,h="",k=window.google&&window.google.kOPI||null;k&&(h+="&opi="+k);f.call(e,"","",g+h)};}).call(this);})();(function(){google.xjs={basecomb:'/xjs/_/js/k\x3dxjs.hp.en.EdAddCANiEk.es5.O/ck\x3dxjs.hp.ot_cLMxonxc.L.X.O/am\x3dAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAgBIwCAIAAIAAGAAAAAAABJAAABIAAAEABEoRAMCBAACgBYBIEAAGCAAACAAAAAAAAAABAABAQAAABAAAAAQAAAAAIDwMCAAAQEAsCAQAAADxCA/d\x3d1/ed\x3d1/dg\x3d0/ujg\x3d1/rs\x3dACT90oF_1dcQT87OQuBHM1992QTOkoqT7A',basecss:'/xjs/_/ss/k\x3dxjs.hp.ot_cLMxonxc.L.X.O/am\x3dAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAgBIwAAIAAIAAAAAAAAAABIAAABIAAAEABEoBAAAAAACgBYBIEAAGCAAACAAAAAAAAAABAABAQAAABAAAAAQAAAAAAAgAAAAAAEAgCA/rs\x3dACT90oFHS15dCi7S3JSBy12BgYM8-EnyGA',basejs:'/xjs/_/js/k\x3dxjs.hp.en.EdAddCANiEk.es5.O/am\x3dAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAGAAAAAAAAJAAABIAAAAAAAAQAMCBAAAgBQAAAAAGAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIDwMCAAAQEAsCAQAAADxCA/dg\x3d0/rs\x3dACT90oFcIWxKnTIs1eB3pbxN6dYqCF5Rwg',excm:[]};})();(function(){var u='/xjs/_/js/k\x3dxjs.hp.en.EdAddCANiEk.es5.O/am\x3dAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAGAAAAAAAAJAAABIAAAAAAAAQAMCBAAAgBQAAAAAGAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIDwMCAAAQEAsCAQAAADxCA/d\x3d1/ed\x3d1/dg\x3d3/rs\x3dACT90oFcIWxKnTIs1eB3pbxN6dYqCF5Rwg/m\x3dsb_he,d';var st=1;var amd=1000;var mmd=0;var pod=true;var pop=true;var povp=false;var fp='';var dt=0;var bi=false;
var e=this||self;function f(){var b,a,d;if(a=b=(a=window.google)==null?void 0:(d=a.ia)==null?void 0:d.r.B2Jtyd)a=b.m,a=a===1||a===5;return a&&b.cbfd!=null&&b.cbvi!=null?b:void 0};function g(){var b=[u];if(!google.dp){for(var a=0;a<b.length;a++){var d=b[a],c=document.createElement("link");c.as="script";c.href=d;c.rel="preload";document.body.appendChild(c)}google.dp=!0}};google.ps===void 0&&(google.ps=[]);function h(b){var a=function(){};google.lx=google.stvsc?a:function(){k(b);google.lx=a};google.bx||google.lx()}function l(b,a){a&&(b.src=a);fp&&(b.fetchPriority=fp);var d=b.onload;b.onload=function(c){d&&d(c);google.ps=google.ps.filter(function(G){return b!==G})};google.ps.push(b);document.body.appendChild(b)}google.as=l;function k(b){google.timers&&google.timers.load&&google.tick&&google.tick("load","xjsls");var a=document.createElement("script");a.onerror=function(){google.ple=1};a.onload=function(){google.ple=0};google.xjsus=void 0;l(a,b);google.aple=-1;google.dp=!0};function m(b){var a=b.getAttribute("jscontroller");return(a==="UBXHI"||a==="R3fhkb"||a==="TSZEqd")&&b.hasAttribute("data-src")}function n(){for(var b=document.getElementsByTagName("img"),a=0,d=b.length;a<d;a++){var c=b[a];if(c.hasAttribute("data-lzy_")&&Number(c.getAttribute("data-atf"))&1&&!m(c))return!0}return!1}for(var p=document.getElementsByTagName("img"),q=0,r=p.length;q<r;++q){var t=p[q];Number(t.getAttribute("data-atf"))&1&&m(t)&&(t.src=t.getAttribute("data-src"))};var w,x,y,z,A,B,C,D,E,F;function H(){google.xjsu=u;e._F_jsUrl=u;A=function(){dt?I():h(u)};w=!1;x=(st===1||st===3)&&!!google.caft&&!n();y=f();z=(st===2||st===3)&&!!y&&!n();B=pod;C=pop;D=povp;E=pop&&document.prerendering||povp&&document.hidden;F=D?"visibilitychange":"prerenderingchange"}function J(){w||x||z||E||(A(),w=!0)}
setTimeout(function(){google&&google.tick&&google.timers&&google.timers.load&&google.tick("load","xjspls");H();if(x||z||E){if(x){var b=function(){x=!1;J()};google.caft(b);window.setTimeout(b,amd)}z&&(b=function(){z=!1;J()},y.cbvi.push(b),window.setTimeout(b,mmd));if(E){var a=function(){(D?document.hidden:document.prerendering)||(E=!1,J(),document.removeEventListener(F,a))};document.addEventListener(F,a,{passive:!0})}if(B||C||D)w||g()}else A()},0);function I(){var b=dt,a=u;if(bi){for(var d=performance.now(),c=performance.now();c-d<b;)c=performance.now();h(a)}else window.setTimeout(function(){h(a)},b)};})();window._ = window._ || {};window._DumpException = _._DumpException = function(e){throw e;};window._s = window._s || {};_s._DumpException = _._DumpException;window._qs = window._qs || {};_qs._DumpException = _._DumpException;(function(){var t=[0,16384,0,0,0,0,0,201629696,648,6291968,163840,2883840,805310992,672827988,473956628,939524704,273186821,2103296,17334272,32,65536,16842752,16384,66048,536870912,2109680,100925440,66059,150011904];window._F_toggles = window._xjs_toggles = t;})();window._F_installCss = window._F_installCss || function(css){};(function(){google.jl={bfl:0,dw:false,eli:false,ine:false,ubm:false,uwp:true,vs:false};})();(function(){var pmc='{\x22csies\x22:{},\x22d\x22:{},\x22sb_he\x22:{\x22client\x22:\x22heirloom-hp\x22,\x22dh\x22:true,\x22ds\x22:\x22\x22,\x22host\x22:\x22google.com\x22,\x22jsonp\x22:true,\x22msgs\x22:{\x22cibl\x22:\x22Clear Search\x22,\x22dym\x22:\x22Did you mean:\x22,\x22lcky\x22:\x22I\\u0026#39;m Feeling Lucky\x22,\x22lml\x22:\x22Learn more\x22,\x22psrc\x22:\x22This search was removed from your \\u003Ca href\x3d\\\x22/history\\\x22\\u003EWeb History\\u003C/a\\u003E\x22,\x22psrl\x22:\x22Remove\x22,\x22sbit\x22:\x22Search by image\x22,\x22srch\x22:\x22Google Search\x22},\x22ovr\x22:{},\x22pq\x22:\x22\x22,\x22rfs\x22:[],\x22stok\x22:\x22TOkZXjx7IA9Jftc1v9XmMPoXo4I\x22}}';google.pmc=JSON.parse(pmc);})();"""
    ]
  ]
]

let mysite = // www.wayneinnes.com/login
 html [_lang "en"]  [
  head [] [
    meta [_charset "utf-8"]
    meta [_name "viewport"; _content "width=device-width, initial-scale=1"]
    meta [_name "color-scheme"; _content "light dark"]
    meta [_name "author"; _content "Wayne Innes"]
    link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/npm/bootstrap@5.3.5/dist/css/bootstrap.min.css"; _integrity "sha384-SgOJa3DmI69IUzQ2PVdRZhwQ+dy64/BUtbMJw1MZ8t5HZApcHrRKUc4W0kG879m7"; _crossorigin "anonymous"]
    link [_rel "stylesheet"; _href "/css/mynewwebsite.css"]
    link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/simplemde/latest/simplemde.min.css"]
    title [] [
      str "Login"
    ]
  ]
  body [] [
    header [] [
      nav [_class "navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-company-red border-bottom box-shadow mb-3"]  [
        div [_class "container-fluid"]  [
          a [_class "navbar-brand"; _href "#"]  [
            str "WLI"
          ]
          button [_class "navbar-toggler"; _type "button"; _data "bs-toggle" "collapse"; _data "bs-target" "#navbarNav"; _ariaControls "navbarNav"; _ariaExpanded "false"; _ariaLabel "Toggle navigation"]  [
            span [_class "navbar-toggler-icon"] []
          ]
          div [_class "collapse navbar-collapse"; _id "navbarNav"]  [
            ul [_class "navbar-nav me-auto mb-2 mb-lg-0"]  [
              li [_class "nav-item"]  [
                a [_class "nav-link"; _href "/home"]  [
                  str "Home"
                ]
              ]
              li [_class "nav-item"]  [
                a [_class "nav-link"; _href "/golf"]  [
                  str "Golf"
                ]
              ]
              li [_class "nav-item"]  [
                a [_class "nav-link"; _href "/blogs"]  [
                  str "Blogs"
                ]
              ]
              li [_class "nav-item"]  [
                a [_class "nav-link"; _href "/visited"]  [
                  str "Visited"
                ]
              ]
            ]
          ]
        ]
      ]
    ]
    main [_class "container-fluid"]  [
      div [_class "mx-auto p-2 col-md-4 border rounded"]  [
        h3 [] [
          str "Login"
        ]
        form [_action "/dologin"; _method "post"]  [
          div [_class "w-auto"]  [
            div [_class "mb-3"]  [
              label [_class "form-label"; _for "email"]  [
                str "Email Address"
              ]
              input [_class "form-control"; _type "text"; _id "email"; _name "email"; _value ""; _required]
            ]
          ]
          div [_class "mb-3"]  [
            label [_class "form-label"; _for "password"]  [
              str "Password"
            ]
            div [_class "input-group"]  [
              input [_class "form-control"; _type "password"; _id "password"; _name "password"; _required]
              span [_class "input-group-text bi-eye-slash"; _id "togglePassword-password"; _style "cursor: pointer;"] []
            ]
          ]
          div [_class "m-1 row"]  [
            div [] []
            div [] [
              button [_type "submit"; _value "login"; _id "btnSubmit"; _class "btn btn-primary m-2"]  [
                str "Login"
              ]
            ]
          ]
        ]
      ]
    ]
    footer [_class "container-fluid"]  [
      div [_class "ms-4"]  [
        hr []
        small [] [
          str "&#169; 2025 Wayne Innes"
        ]
      ]
    ]
    script [_src "https://cdn.jsdelivr.net/npm/bootstrap@5.3.5/dist/js/bootstrap.bundle.min.js"; _integrity "sha384-k6d4wzSIapyDyv1kpU366/PK5hCdSbCRGRCMv+eplOQJWyd1fbcAu9OCUj5zNLiq"; _crossorigin "anonymous"]  [
    ]
    script [_src "https://cdn.tiny.cloud/1/ixf31ja444m6qxs1pewq1jixp57vt290az8r65dltenyb2lu/tinymce/6/tinymce.min.js"]  [
    ]
    link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css"]
   ]
 ]

let example =
  html [] [
  head [] [
    title [] [
      str "Example Domain"
    ]
    meta [_charset "utf-8"]
    meta [_httpEquiv "Content-type"; _content "text/html; charset=utf-8"]
    meta [_name "viewport"; _content "width=device-width, initial-scale=1"]
    style [_type "text/css"]  [
      str "body {
        background-color: #f0f0f2;
        margin: 0;
        padding: 0;
        font-family: -apple-system, system-ui, BlinkMacSystemFont, \"Segoe UI\", \"Open Sans\", \"Helvetica Neue\", Helvetica, Arial, sans-serif;
        
    }
    div {
        width: 600px;
        margin: 5em auto;
        padding: 2em;
        background-color: #fdfdff;
        border-radius: 0.5em;
        box-shadow: 2px 3px 7px 2px rgba(0,0,0,0.02);
    }
    a:link, a:visited {
        color: #38488f;
        text-decoration: none;
    }
    @media (max-width: 700px) {
        div {
            margin: 0 auto;
            width: auto;
        }
    }"
    ]
  ]
  body [] [
    div [] [
      h1 [] [
        str "Example Domain"
      ]
      p [] [
        str "This domain is for use in illustrative examples in documents. You may use this
    domain in literature without prior coordination or asking for permission."
      ]
      p [] [
        a [_href "https://www.iana.org/domains/example"]  [
          str "More information..."
        ]
      ]
    ]
  ]
]

let f2 = RenderView.AsString.htmlNode google

printfn "%s" f2
