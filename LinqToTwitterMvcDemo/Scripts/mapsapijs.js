


<!DOCTYPE html>
<html lang="en" class="">
  <head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# object: http://ogp.me/ns/object# article: http://ogp.me/ns/article# profile: http://ogp.me/ns/profile#">
    <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta http-equiv="Content-Language" content="en">
    
    
    <title>HangItOutTest/mapsapijs.js at master · fletchr0cks/HangItOutTest</title>
    <link rel="search" type="application/opensearchdescription+xml" href="/opensearch.xml" title="GitHub">
    <link rel="fluid-icon" href="https://github.com/fluidicon.png" title="GitHub">
    <link rel="apple-touch-icon" sizes="57x57" href="/apple-touch-icon-114.png">
    <link rel="apple-touch-icon" sizes="114x114" href="/apple-touch-icon-114.png">
    <link rel="apple-touch-icon" sizes="72x72" href="/apple-touch-icon-144.png">
    <link rel="apple-touch-icon" sizes="144x144" href="/apple-touch-icon-144.png">
    <meta property="fb:app_id" content="1401488693436528">

      <meta content="@github" name="twitter:site" /><meta content="summary" name="twitter:card" /><meta content="fletchr0cks/HangItOutTest" name="twitter:title" /><meta content="Contribute to HangItOutTest development by creating an account on GitHub." name="twitter:description" /><meta content="https://avatars3.githubusercontent.com/u/1506879?v=3&amp;s=400" name="twitter:image:src" />
      <meta content="GitHub" property="og:site_name" /><meta content="object" property="og:type" /><meta content="https://avatars3.githubusercontent.com/u/1506879?v=3&amp;s=400" property="og:image" /><meta content="fletchr0cks/HangItOutTest" property="og:title" /><meta content="https://github.com/fletchr0cks/HangItOutTest" property="og:url" /><meta content="Contribute to HangItOutTest development by creating an account on GitHub." property="og:description" />
      <meta name="browser-stats-url" content="/_stats">
    <link rel="assets" href="https://assets-cdn.github.com/">
    <link rel="conduit-xhr" href="https://ghconduit.com:25035">
    <link rel="xhr-socket" href="/_sockets">
    <meta name="pjax-timeout" content="1000">
    <link rel="sudo-modal" href="/sessions/sudo_modal">

    <meta name="msapplication-TileImage" content="/windows-tile.png">
    <meta name="msapplication-TileColor" content="#ffffff">
    <meta name="selected-link" value="repo_source" data-pjax-transient>
      <meta name="google-analytics" content="UA-3769691-2">

    <meta content="collector.githubapp.com" name="octolytics-host" /><meta content="collector-cdn.github.com" name="octolytics-script-host" /><meta content="github" name="octolytics-app-id" /><meta content="B00C6B8C:0963:67E160:55035A1D" name="octolytics-dimension-request_id" /><meta content="1506879" name="octolytics-actor-id" /><meta content="fletchr0cks" name="octolytics-actor-login" /><meta content="b96f71f9044e12af8bf5f75c7763c0a95f2a956b7f37d5892b40ff49a9184d54" name="octolytics-actor-hash" />
    
    <meta content="Rails, view, blob#show" name="analytics-event" />

    
    <link rel="icon" type="image/x-icon" href="https://assets-cdn.github.com/favicon.ico">


    <meta content="authenticity_token" name="csrf-param" />
<meta content="fdQDOjdHF6fLbR1KPqT26f73ugjyyLG4X9xW0l7+hS8GfXNU1S16wsrXheVbixkddDBcQ2a2UkxnnpW3W0qeyA==" name="csrf-token" />

    <link href="https://assets-cdn.github.com/assets/github-85e4ac99403eefa73664d9b122f27095fee8b7333e67f34fa34480ae497f7555.css" media="all" rel="stylesheet" />
    <link href="https://assets-cdn.github.com/assets/github2-901780fdaaa6b0f56b2004899a7a24194bf4217cc7864291a9f68fa3a9264fdf.css" media="all" rel="stylesheet" />
    
    


    <meta http-equiv="x-pjax-version" content="8060cc7a9543870628764b4fdb4264ea">

      
  <meta name="description" content="Contribute to HangItOutTest development by creating an account on GitHub.">
  <meta name="go-import" content="github.com/fletchr0cks/HangItOutTest git https://github.com/fletchr0cks/HangItOutTest.git">

  <meta content="1506879" name="octolytics-dimension-user_id" /><meta content="fletchr0cks" name="octolytics-dimension-user_login" /><meta content="3638794" name="octolytics-dimension-repository_id" /><meta content="fletchr0cks/HangItOutTest" name="octolytics-dimension-repository_nwo" /><meta content="true" name="octolytics-dimension-repository_public" /><meta content="false" name="octolytics-dimension-repository_is_fork" /><meta content="3638794" name="octolytics-dimension-repository_network_root_id" /><meta content="fletchr0cks/HangItOutTest" name="octolytics-dimension-repository_network_root_nwo" />
  <link href="https://github.com/fletchr0cks/HangItOutTest/commits/master.atom" rel="alternate" title="Recent Commits to HangItOutTest:master" type="application/atom+xml">

  </head>


  <body class="logged_in  env-production windows vis-public page-blob">
    <a href="#start-of-content" tabindex="1" class="accessibility-aid js-skip-to-content">Skip to content</a>
    <div class="wrapper">
      
      
      


        <div class="header header-logged-in true" role="banner">
  <div class="container clearfix">

    <a class="header-logo-invertocat" href="https://github.com/" data-hotkey="g d" aria-label="Homepage" data-ga-click="Header, go to dashboard, icon:logo">
  <span class="mega-octicon octicon-mark-github"></span>
</a>


      <div class="site-search repo-scope js-site-search" role="search">
          <form accept-charset="UTF-8" action="/fletchr0cks/HangItOutTest/search" class="js-site-search-form" data-global-search-url="/search" data-repo-search-url="/fletchr0cks/HangItOutTest/search" method="get"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /></div>
  <input type="text"
    class="js-site-search-field is-clearable"
    data-hotkey="s"
    name="q"
    placeholder="Search"
    data-global-scope-placeholder="Search GitHub"
    data-repo-scope-placeholder="Search"
    tabindex="1"
    autocapitalize="off">
  <div class="scope-badge">This repository</div>
</form>
      </div>
      <ul class="header-nav left" role="navigation">
        <li class="header-nav-item explore">
          <a class="header-nav-link" href="/explore" data-ga-click="Header, go to explore, text:explore">Explore</a>
        </li>
          <li class="header-nav-item">
            <a class="header-nav-link" href="https://gist.github.com" data-ga-click="Header, go to gist, text:gist">Gist</a>
          </li>
          <li class="header-nav-item">
            <a class="header-nav-link" href="/blog" data-ga-click="Header, go to blog, text:blog">Blog</a>
          </li>
        <li class="header-nav-item">
          <a class="header-nav-link" href="https://help.github.com" data-ga-click="Header, go to help, text:help">Help</a>
        </li>
      </ul>

    
<ul class="header-nav user-nav right" id="user-links">
  <li class="header-nav-item dropdown js-menu-container">
    <a class="header-nav-link name" href="/fletchr0cks" data-ga-click="Header, go to profile, text:username">
      <img alt="Fletch" class="avatar" data-user="1506879" height="20" src="https://avatars3.githubusercontent.com/u/1506879?v=3&amp;s=40" width="20" />
      <span class="css-truncate">
        <span class="css-truncate-target">fletchr0cks</span>
      </span>
    </a>
  </li>

  <li class="header-nav-item dropdown js-menu-container">
    <a class="header-nav-link js-menu-target tooltipped tooltipped-s" href="#" aria-label="Create new..." data-ga-click="Header, create new, icon:add">
      <span class="octicon octicon-plus"></span>
      <span class="dropdown-caret"></span>
    </a>

    <div class="dropdown-menu-content js-menu-content">
      
<ul class="dropdown-menu">
  <li>
    <a href="/new" data-ga-click="Header, create new repository, icon:repo"><span class="octicon octicon-repo"></span> New repository</a>
  </li>
  <li>
    <a href="/organizations/new" data-ga-click="Header, create new organization, icon:organization"><span class="octicon octicon-organization"></span> New organization</a>
  </li>


    <li class="dropdown-divider"></li>
    <li class="dropdown-header">
      <span title="fletchr0cks/HangItOutTest">This repository</span>
    </li>
      <li>
        <a href="/fletchr0cks/HangItOutTest/issues/new" data-ga-click="Header, create new issue, icon:issue"><span class="octicon octicon-issue-opened"></span> New issue</a>
      </li>
      <li>
        <a href="/fletchr0cks/HangItOutTest/settings/collaboration" data-ga-click="Header, create new collaborator, icon:person"><span class="octicon octicon-person"></span> New collaborator</a>
      </li>
</ul>

    </div>
  </li>

  <li class="header-nav-item">
        <a href="/notifications" aria-label="You have no unread notifications" class="header-nav-link notification-indicator tooltipped tooltipped-s" data-ga-click="Header, go to notifications, icon:read" data-hotkey="g n">
        <span class="mail-status all-read"></span>
        <span class="octicon octicon-inbox"></span>
</a>
  </li>

  <li class="header-nav-item">
    <a class="header-nav-link tooltipped tooltipped-s" href="/settings/profile" id="account_settings" aria-label="Settings" data-ga-click="Header, go to settings, icon:settings">
      <span class="octicon octicon-gear"></span>
    </a>
  </li>

  <li class="header-nav-item">
    <form accept-charset="UTF-8" action="/logout" class="logout-form" method="post"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /><input name="authenticity_token" type="hidden" value="vOFeidhrI1LmRDakJf5jSwxMqazGlhivju369X6vpj+fqXTlqDezIMMd6bORT4kN4ahWuSXPBtN5QtKl7vcx/w==" /></div>
      <button class="header-nav-link sign-out-button tooltipped tooltipped-s" aria-label="Sign out" data-ga-click="Header, sign out, icon:logout">
        <span class="octicon octicon-sign-out"></span>
      </button>
</form>  </li>

</ul>


    
  </div>
</div>

        

        
<div class="flash-global js-notice flash-warn">
<div class="container">
    <h2>
      You don't have any verified emails.  We recommend <a href="https://github.com/settings/emails">verifying</a> at least one email.
    </h2>
    <p>
Email verification helps our support team verify ownership if you lose account access and allows you to receive all the notifications you ask for.
    </p>


















</div>
</div>


      <div id="start-of-content" class="accessibility-aid"></div>
          <div class="site" itemscope itemtype="http://schema.org/WebPage">
    <div id="js-flash-container">
      
    </div>
    <div class="pagehead repohead instapaper_ignore readability-menu">
      <div class="container">
        
<ul class="pagehead-actions">

  <li>
      <form accept-charset="UTF-8" action="/notifications/subscribe" class="js-social-container" data-autosubmit="true" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /><input name="authenticity_token" type="hidden" value="tMrW2zNJN27oJdQXWb4PzmIAsRmdpJyqWkpgQODX7BCev/YPxdPtoUQZgt9RWzuLK/CIw05+UZIjCSK/m9Yjwg==" /></div>    <input id="repository_id" name="repository_id" type="hidden" value="3638794" />

      <div class="select-menu js-menu-container js-select-menu">
        <a href="/fletchr0cks/HangItOutTest/subscription"
          class="minibutton select-menu-button with-count js-menu-target" role="button" tabindex="0" aria-haspopup="true"
          data-ga-click="Repository, click Watch settings, action:blob#show">
          <span class="js-select-button">
            <span class="octicon octicon-eye"></span>
            Unwatch
          </span>
        </a>
        <a class="social-count js-social-count" href="/fletchr0cks/HangItOutTest/watchers">
          1
        </a>
        
        <div class="select-menu-modal-holder">
          <div class="select-menu-modal subscription-menu-modal js-menu-content" aria-hidden="true">
            <div class="select-menu-header">
              <span class="select-menu-title">Notifications</span>
              <span class="octicon octicon-x js-menu-close" role="button" aria-label="Close"></span>
            </div>

            <div class="select-menu-list js-navigation-container" role="menu">

              <div class="select-menu-item js-navigation-item " role="menuitem" tabindex="0">
                <span class="select-menu-item-icon octicon octicon-check"></span>
                <div class="select-menu-item-text">
                  <input id="do_included" name="do" type="radio" value="included" />
                  <span class="select-menu-item-heading">Not watching</span>
                  <span class="description">Be notified when participating or @mentioned.</span>
                  <span class="js-select-button-text hidden-select-button-text">
                    <span class="octicon octicon-eye"></span>
                    Watch
                  </span>
                </div>
              </div>

              <div class="select-menu-item js-navigation-item selected" role="menuitem" tabindex="0">
                <span class="select-menu-item-icon octicon octicon octicon-check"></span>
                <div class="select-menu-item-text">
                  <input checked="checked" id="do_subscribed" name="do" type="radio" value="subscribed" />
                  <span class="select-menu-item-heading">Watching</span>
                  <span class="description">Be notified of all conversations.</span>
                  <span class="js-select-button-text hidden-select-button-text">
                    <span class="octicon octicon-eye"></span>
                    Unwatch
                  </span>
                </div>
              </div>

              <div class="select-menu-item js-navigation-item " role="menuitem" tabindex="0">
                <span class="select-menu-item-icon octicon octicon-check"></span>
                <div class="select-menu-item-text">
                  <input id="do_ignore" name="do" type="radio" value="ignore" />
                  <span class="select-menu-item-heading">Ignoring</span>
                  <span class="description">Never be notified.</span>
                  <span class="js-select-button-text hidden-select-button-text">
                    <span class="octicon octicon-mute"></span>
                    Stop ignoring
                  </span>
                </div>
              </div>

            </div>

          </div>
        </div>
      </div>
</form>
  </li>

  <li>
    
  <div class="js-toggler-container js-social-container starring-container on">

    <form accept-charset="UTF-8" action="/fletchr0cks/HangItOutTest/unstar" class="js-toggler-form starred js-unstar-button" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /><input name="authenticity_token" type="hidden" value="7xPfMhi+EWVyBhB/EQaVngbSLwcUx5sM/2dQgIYoX1qcUAvb6TLYF+OMsHH2QVuL5+X/NJOK+P/DD6yGL007Fg==" /></div>
      <button
        class="minibutton with-count js-toggler-target"
        aria-label="Unstar this repository" title="Unstar fletchr0cks/HangItOutTest"
        data-ga-click="Repository, click unstar button, action:blob#show; text:Unstar">
        <span class="octicon octicon-star"></span>
        Unstar
      </button>
        <a class="social-count js-social-count" href="/fletchr0cks/HangItOutTest/stargazers">
          1
        </a>
</form>
    <form accept-charset="UTF-8" action="/fletchr0cks/HangItOutTest/star" class="js-toggler-form unstarred js-star-button" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /><input name="authenticity_token" type="hidden" value="n1Dp7ZHv1XapBcEVLh/ur4w2hhaXXxennwTsmqwITHSJzUNGhQoVhAZ0xPI5fl7yLRSQJnODXpKyQYVFDDPK0g==" /></div>
      <button
        class="minibutton with-count js-toggler-target"
        aria-label="Star this repository" title="Star fletchr0cks/HangItOutTest"
        data-ga-click="Repository, click star button, action:blob#show; text:Star">
        <span class="octicon octicon-star"></span>
        Star
      </button>
        <a class="social-count js-social-count" href="/fletchr0cks/HangItOutTest/stargazers">
          1
        </a>
</form>  </div>

  </li>

        <li>
          <form accept-charset="UTF-8" action="/fletchr0cks/HangItOutTest/fork" method="post"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /><input name="authenticity_token" type="hidden" value="FXC9TQhhhpCLtiLt6+OXaP8htk5xz0tR2NTPhbLkYBjuIeDHfNT4YQnUdgeGSecdgfvaqs/NWOBf90aEA1kmww==" /></div>
            <button
                type="submit"
                class="minibutton with-count"
                data-ga-click="Repository, show fork modal, action:blob#show; text:Fork"
                title="Fork your own copy of fletchr0cks/HangItOutTest to your account"
                aria-label="Fork your own copy of fletchr0cks/HangItOutTest to your account">
              <span class="octicon octicon-repo-forked"></span>
              Fork
            </button>
            <a href="/fletchr0cks/HangItOutTest/network" class="social-count">0</a>
</form>        </li>

</ul>

        <h1 itemscope itemtype="http://data-vocabulary.org/Breadcrumb" class="entry-title public">
          <span class="mega-octicon octicon-repo"></span>
          <span class="author"><a href="/fletchr0cks" class="url fn" itemprop="url" rel="author"><span itemprop="title">fletchr0cks</span></a></span><!--
       --><span class="path-divider">/</span><!--
       --><strong><a href="/fletchr0cks/HangItOutTest" class="js-current-repository" data-pjax="#js-repo-pjax-container">HangItOutTest</a></strong>

          <span class="page-context-loader">
            <img alt="" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-e513294efa576953719e4e2de888dd9cf929b7d62ed8d05f25e731d02452ab6c.gif" width="16" />
          </span>

        </h1>
      </div><!-- /.container -->
    </div><!-- /.repohead -->

    <div class="container">
      <div class="repository-with-sidebar repo-container new-discussion-timeline  ">
        <div class="repository-sidebar clearfix">
            
<nav class="sunken-menu repo-nav js-repo-nav js-sidenav-container-pjax js-octicon-loaders"
     role="navigation"
     data-pjax="#js-repo-pjax-container"
     data-issue-count-url="/fletchr0cks/HangItOutTest/issues/counts">
  <ul class="sunken-menu-group">
    <li class="tooltipped tooltipped-w" aria-label="Code">
      <a href="/fletchr0cks/HangItOutTest" aria-label="Code" class="selected js-selected-navigation-item sunken-menu-item" data-hotkey="g c" data-selected-links="repo_source repo_downloads repo_commits repo_releases repo_tags repo_branches /fletchr0cks/HangItOutTest">
        <span class="octicon octicon-code"></span> <span class="full-word">Code</span>
        <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-e513294efa576953719e4e2de888dd9cf929b7d62ed8d05f25e731d02452ab6c.gif" width="16" />
</a>    </li>

      <li class="tooltipped tooltipped-w" aria-label="Issues">
        <a href="/fletchr0cks/HangItOutTest/issues" aria-label="Issues" class="js-selected-navigation-item sunken-menu-item" data-hotkey="g i" data-selected-links="repo_issues repo_labels repo_milestones /fletchr0cks/HangItOutTest/issues">
          <span class="octicon octicon-issue-opened"></span> <span class="full-word">Issues</span>
          <span class="js-issue-replace-counter"></span>
          <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-e513294efa576953719e4e2de888dd9cf929b7d62ed8d05f25e731d02452ab6c.gif" width="16" />
</a>      </li>

    <li class="tooltipped tooltipped-w" aria-label="Pull Requests">
      <a href="/fletchr0cks/HangItOutTest/pulls" aria-label="Pull Requests" class="js-selected-navigation-item sunken-menu-item" data-hotkey="g p" data-selected-links="repo_pulls /fletchr0cks/HangItOutTest/pulls">
          <span class="octicon octicon-git-pull-request"></span> <span class="full-word">Pull Requests</span>
          <span class="js-pull-replace-counter"></span>
          <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-e513294efa576953719e4e2de888dd9cf929b7d62ed8d05f25e731d02452ab6c.gif" width="16" />
</a>    </li>


      <li class="tooltipped tooltipped-w" aria-label="Wiki">
        <a href="/fletchr0cks/HangItOutTest/wiki" aria-label="Wiki" class="js-selected-navigation-item sunken-menu-item" data-hotkey="g w" data-selected-links="repo_wiki /fletchr0cks/HangItOutTest/wiki">
          <span class="octicon octicon-book"></span> <span class="full-word">Wiki</span>
          <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-e513294efa576953719e4e2de888dd9cf929b7d62ed8d05f25e731d02452ab6c.gif" width="16" />
</a>      </li>
  </ul>
  <div class="sunken-menu-separator"></div>
  <ul class="sunken-menu-group">

    <li class="tooltipped tooltipped-w" aria-label="Pulse">
      <a href="/fletchr0cks/HangItOutTest/pulse" aria-label="Pulse" class="js-selected-navigation-item sunken-menu-item" data-selected-links="pulse /fletchr0cks/HangItOutTest/pulse">
        <span class="octicon octicon-pulse"></span> <span class="full-word">Pulse</span>
        <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-e513294efa576953719e4e2de888dd9cf929b7d62ed8d05f25e731d02452ab6c.gif" width="16" />
</a>    </li>

    <li class="tooltipped tooltipped-w" aria-label="Graphs">
      <a href="/fletchr0cks/HangItOutTest/graphs" aria-label="Graphs" class="js-selected-navigation-item sunken-menu-item" data-selected-links="repo_graphs repo_contributors /fletchr0cks/HangItOutTest/graphs">
        <span class="octicon octicon-graph"></span> <span class="full-word">Graphs</span>
        <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-e513294efa576953719e4e2de888dd9cf929b7d62ed8d05f25e731d02452ab6c.gif" width="16" />
</a>    </li>
  </ul>


    <div class="sunken-menu-separator"></div>
    <ul class="sunken-menu-group">
      <li class="tooltipped tooltipped-w" aria-label="Settings">
        <a href="/fletchr0cks/HangItOutTest/settings" aria-label="Settings" class="js-selected-navigation-item sunken-menu-item" data-selected-links="repo_settings /fletchr0cks/HangItOutTest/settings">
          <span class="octicon octicon-tools"></span> <span class="full-word">Settings</span>
          <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-e513294efa576953719e4e2de888dd9cf929b7d62ed8d05f25e731d02452ab6c.gif" width="16" />
</a>      </li>
    </ul>
</nav>

              <div class="only-with-full-nav">
                  
<div class="clone-url open"
  data-protocol-type="http"
  data-url="/users/set_protocol?protocol_selector=http&amp;protocol_type=clone">
  <h3><span class="text-emphasized">HTTPS</span> clone URL</h3>
  <div class="input-group js-zeroclipboard-container">
    <input type="text" class="input-mini input-monospace js-url-field js-zeroclipboard-target"
           value="https://github.com/fletchr0cks/HangItOutTest.git" readonly="readonly">
    <span class="input-group-button">
      <button aria-label="Copy to clipboard" class="js-zeroclipboard minibutton zeroclipboard-button" data-copied-hint="Copied!" type="button"><span class="octicon octicon-clippy"></span></button>
    </span>
  </div>
</div>

  
<div class="clone-url "
  data-protocol-type="ssh"
  data-url="/users/set_protocol?protocol_selector=ssh&amp;protocol_type=clone">
  <h3><span class="text-emphasized">SSH</span> clone URL</h3>
  <div class="input-group js-zeroclipboard-container">
    <input type="text" class="input-mini input-monospace js-url-field js-zeroclipboard-target"
           value="git@github.com:fletchr0cks/HangItOutTest.git" readonly="readonly">
    <span class="input-group-button">
      <button aria-label="Copy to clipboard" class="js-zeroclipboard minibutton zeroclipboard-button" data-copied-hint="Copied!" type="button"><span class="octicon octicon-clippy"></span></button>
    </span>
  </div>
</div>

  
<div class="clone-url "
  data-protocol-type="subversion"
  data-url="/users/set_protocol?protocol_selector=subversion&amp;protocol_type=clone">
  <h3><span class="text-emphasized">Subversion</span> checkout URL</h3>
  <div class="input-group js-zeroclipboard-container">
    <input type="text" class="input-mini input-monospace js-url-field js-zeroclipboard-target"
           value="https://github.com/fletchr0cks/HangItOutTest" readonly="readonly">
    <span class="input-group-button">
      <button aria-label="Copy to clipboard" class="js-zeroclipboard minibutton zeroclipboard-button" data-copied-hint="Copied!" type="button"><span class="octicon octicon-clippy"></span></button>
    </span>
  </div>
</div>



<p class="clone-options">You can clone with
  <a href="#" class="js-clone-selector" data-protocol="http">HTTPS</a>, <a href="#" class="js-clone-selector" data-protocol="ssh">SSH</a>, or <a href="#" class="js-clone-selector" data-protocol="subversion">Subversion</a>.
  <a href="https://help.github.com/articles/which-remote-url-should-i-use" class="help tooltipped tooltipped-n" aria-label="Get help on which URL is right for you.">
    <span class="octicon octicon-question"></span>
  </a>
</p>


  <a href="github-windows://openRepo/https://github.com/fletchr0cks/HangItOutTest" class="minibutton sidebar-button" title="Save fletchr0cks/HangItOutTest to your computer and use it in GitHub Desktop." aria-label="Save fletchr0cks/HangItOutTest to your computer and use it in GitHub Desktop.">
    <span class="octicon octicon-device-desktop"></span>
    Clone in Desktop
  </a>

                <a href="/fletchr0cks/HangItOutTest/archive/master.zip"
                   class="minibutton sidebar-button"
                   aria-label="Download the contents of fletchr0cks/HangItOutTest as a zip file"
                   title="Download the contents of fletchr0cks/HangItOutTest as a zip file"
                   rel="nofollow">
                  <span class="octicon octicon-cloud-download"></span>
                  Download ZIP
                </a>
              </div>
        </div><!-- /.repository-sidebar -->

        <div id="js-repo-pjax-container" class="repository-content context-loader-container" data-pjax-container>
          

<a href="/fletchr0cks/HangItOutTest/blob/4fd93eb6f7995e90db31d10b6e50059bda41c7bd/assets/js/mapsapijs.js" class="hidden js-permalink-shortcut" data-hotkey="y">Permalink</a>

<!-- blob contrib key: blob_contributors:v21:dd73ecd8f5bcda14fe218ba3c42705e8 -->

<div class="file-navigation js-zeroclipboard-container">
  
<div class="select-menu js-menu-container js-select-menu left">
  <span class="minibutton select-menu-button js-menu-target css-truncate" data-hotkey="w"
    data-master-branch="master"
    data-ref="master"
    title="master"
    role="button" aria-label="Switch branches or tags" tabindex="0" aria-haspopup="true">
    <span class="octicon octicon-git-branch"></span>
    <i>branch:</i>
    <span class="js-select-button css-truncate-target">master</span>
  </span>

  <div class="select-menu-modal-holder js-menu-content js-navigation-container" data-pjax aria-hidden="true">

    <div class="select-menu-modal">
      <div class="select-menu-header">
        <span class="select-menu-title">Switch branches/tags</span>
        <span class="octicon octicon-x js-menu-close" role="button" aria-label="Close"></span>
      </div>

      <div class="select-menu-filters">
        <div class="select-menu-text-filter">
          <input type="text" aria-label="Find or create a branch…" id="context-commitish-filter-field" class="js-filterable-field js-navigation-enable" placeholder="Find or create a branch…">
        </div>
        <div class="select-menu-tabs">
          <ul>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="branches" data-filter-placeholder="Find or create a branch…" class="js-select-menu-tab">Branches</a>
            </li>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="tags" data-filter-placeholder="Find a tag…" class="js-select-menu-tab">Tags</a>
            </li>
          </ul>
        </div>
      </div>

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="branches">

        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


            <a class="select-menu-item js-navigation-item js-navigation-open selected"
               href="/fletchr0cks/HangItOutTest/blob/master/assets/js/mapsapijs.js"
               data-name="master"
               data-skip-pjax="true"
               rel="nofollow">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <span class="select-menu-item-text css-truncate-target" title="master">
                master
              </span>
            </a>
        </div>

          <form accept-charset="UTF-8" action="/fletchr0cks/HangItOutTest/branches" class="js-create-branch select-menu-item select-menu-new-item-form js-navigation-item js-new-item-form" method="post"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /><input name="authenticity_token" type="hidden" value="Qyf4RyfBBvRdQavtN+PHB8flkoYX8tOvtU048UN9tur4yuSeRRxjjE4xLQrpnvH0cGL8OxqO9hJPvFDBh6Dklw==" /></div>
            <span class="octicon octicon-git-branch select-menu-item-icon"></span>
            <div class="select-menu-item-text">
              <span class="select-menu-item-heading">Create branch: <span class="js-new-item-name"></span></span>
              <span class="description">from ‘master’</span>
            </div>
            <input type="hidden" name="name" id="name" class="js-new-item-value">
            <input type="hidden" name="branch" id="branch" value="master">
            <input type="hidden" name="path" id="path" value="assets/js/mapsapijs.js">
</form>
      </div>

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="tags">
        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


        </div>

        <div class="select-menu-no-results">Nothing to show</div>
      </div>

    </div>
  </div>
</div>

  <div class="button-group right">
    <a href="/fletchr0cks/HangItOutTest/find/master"
          class="js-show-file-finder minibutton empty-icon tooltipped tooltipped-s"
          data-pjax
          data-hotkey="t"
          aria-label="Quickly jump between files">
      <span class="octicon octicon-list-unordered"></span>
    </a>
    <button aria-label="Copy file path to clipboard" class="js-zeroclipboard minibutton zeroclipboard-button" data-copied-hint="Copied!" type="button"><span class="octicon octicon-clippy"></span></button>
  </div>

  <div class="breadcrumb js-zeroclipboard-target">
    <span class='repo-root js-repo-root'><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/fletchr0cks/HangItOutTest" class="" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">HangItOutTest</span></a></span></span><span class="separator">/</span><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/fletchr0cks/HangItOutTest/tree/master/assets" class="" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">assets</span></a></span><span class="separator">/</span><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/fletchr0cks/HangItOutTest/tree/master/assets/js" class="" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">js</span></a></span><span class="separator">/</span><strong class="final-path">mapsapijs.js</strong>
  </div>
</div>

<include-fragment class="commit commit-loader file-history-tease" src="/fletchr0cks/HangItOutTest/contributors/master/assets/js/mapsapijs.js">
  <div class="file-history-tease-header">
    Fetching contributors&hellip;
  </div>

  <div class="participation">
    <p class="loader-loading"><img alt="" height="16" src="https://assets-cdn.github.com/assets/spinners/octocat-spinner-32-EAF2F5-0bdc57d34b85c4a4de9d0d1db10cd70e8a95f33ff4f46c5a8c48b4bf4e5a9abe.gif" width="16" /></p>
    <p class="loader-error">Cannot retrieve contributors at this time</p>
  </div>
</include-fragment>
<div class="file">
  <div class="file-header">
    <div class="file-actions">
      <div class="button-group">
        <a href="/fletchr0cks/HangItOutTest/raw/master/assets/js/mapsapijs.js" class="minibutton " id="raw-url">Raw</a>
          <a href="/fletchr0cks/HangItOutTest/blame/master/assets/js/mapsapijs.js" class="minibutton js-update-url-with-hash">Blame</a>
        <a href="/fletchr0cks/HangItOutTest/commits/master/assets/js/mapsapijs.js" class="minibutton " rel="nofollow">History</a>
      </div><!-- /.button-group -->

        <a class="octicon-button tooltipped tooltipped-nw"
           href="github-windows://openRepo/https://github.com/fletchr0cks/HangItOutTest?branch=master&amp;filepath=assets%2Fjs%2Fmapsapijs.js" aria-label="Open this file in GitHub for Windows">
            <span class="octicon octicon-device-desktop"></span>
        </a>

            <form accept-charset="UTF-8" action="/fletchr0cks/HangItOutTest/edit/master/assets/js/mapsapijs.js" aria-label="Edit this file" class="tooltipped tooltipped-e inline-form edit-file-form" method="post"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /><input name="authenticity_token" type="hidden" value="YMusEFk7X6C2SgdcuVeIbrAROeGzM9ZlKAhA0EQmYjlfW+5VAVM+SNAiTyIjmv3Gau6uPnv958KZtSycjq/Jrg==" /></div>
              <button class="web-edit-button"
                      type="submit"
                      data-hotkey="e"
                      data-disable-with>
                <span class="octicon octicon-pencil"></span>
              </button>
</form>
          <form accept-charset="UTF-8" action="/fletchr0cks/HangItOutTest/delete/master/assets/js/mapsapijs.js" aria-label="Delete this file" class="tooltipped tooltipped-s inline-form delete-file-form" method="post"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /><input name="authenticity_token" type="hidden" value="DP/w1c7LTXVsqHNpbclRBPCXm10BL+S0KaI70VhfjsrU4jmPb73lborx1BfhZJkG4G+wii03/HI4aaSJ8Hfu3Q==" /></div>
            <button class="web-edit-button"
                    type="submit"
                    data-disable-with>
              <span class="octicon octicon-trashcan "></span>
            </button>
</form>      </a>
    </div><!-- /.actions -->
    <div class="file-info">
        24 lines (18 sloc)
        <span class="file-info-divider"></span>
      4.706 kb
    </div>
  </div>
  
  <div class="blob-wrapper data type-javascript">
      <table class="highlight tab-size-8 js-file-line-container">
      <tr>
        <td id="L1" class="blob-num js-line-number" data-line-number="1"></td>
        <td id="LC1" class="blob-code js-file-line">
</td>
      </tr>
      <tr>
        <td id="L2" class="blob-num js-line-number" data-line-number="2"></td>
        <td id="LC2" class="blob-code js-file-line">
</td>
      </tr>
      <tr>
        <td id="L3" class="blob-num js-line-number" data-line-number="3"></td>
        <td id="LC3" class="blob-code js-file-line"><span class="pl-s3">window</span>.google <span class="pl-k">=</span> <span class="pl-s3">window</span>.google <span class="pl-k">||</span> {};</td>
      </tr>
      <tr>
        <td id="L4" class="blob-num js-line-number" data-line-number="4"></td>
        <td id="LC4" class="blob-code js-file-line">google.maps <span class="pl-k">=</span> google.maps <span class="pl-k">||</span> {};</td>
      </tr>
      <tr>
        <td id="L5" class="blob-num js-line-number" data-line-number="5"></td>
        <td id="LC5" class="blob-code js-file-line">(<span class="pl-st">function</span>() {</td>
      </tr>
      <tr>
        <td id="L6" class="blob-num js-line-number" data-line-number="6"></td>
        <td id="LC6" class="blob-code js-file-line">  </td>
      </tr>
      <tr>
        <td id="L7" class="blob-num js-line-number" data-line-number="7"></td>
        <td id="LC7" class="blob-code js-file-line">  <span class="pl-st">function</span> <span class="pl-en">getScript</span>(<span class="pl-vpf">src</span>) {</td>
      </tr>
      <tr>
        <td id="L8" class="blob-num js-line-number" data-line-number="8"></td>
        <td id="LC8" class="blob-code js-file-line">    <span class="pl-s3">document</span>.<span class="pl-s3">write</span>(<span class="pl-s1"><span class="pl-pds">&#39;</span>&lt;<span class="pl-pds">&#39;</span></span> <span class="pl-k">+</span> <span class="pl-s1"><span class="pl-pds">&#39;</span>script src=&quot;<span class="pl-pds">&#39;</span></span> <span class="pl-k">+</span> src <span class="pl-k">+</span> <span class="pl-s1"><span class="pl-pds">&#39;</span>&quot;<span class="pl-pds">&#39;</span></span> <span class="pl-k">+</span></td>
      </tr>
      <tr>
        <td id="L9" class="blob-num js-line-number" data-line-number="9"></td>
        <td id="LC9" class="blob-code js-file-line">                   <span class="pl-s1"><span class="pl-pds">&#39;</span> type=&quot;text/javascript&quot;&gt;&lt;<span class="pl-pds">&#39;</span></span> <span class="pl-k">+</span> <span class="pl-s1"><span class="pl-pds">&#39;</span>/script&gt;<span class="pl-pds">&#39;</span></span>);</td>
      </tr>
      <tr>
        <td id="L10" class="blob-num js-line-number" data-line-number="10"></td>
        <td id="LC10" class="blob-code js-file-line">  }</td>
      </tr>
      <tr>
        <td id="L11" class="blob-num js-line-number" data-line-number="11"></td>
        <td id="LC11" class="blob-code js-file-line">  </td>
      </tr>
      <tr>
        <td id="L12" class="blob-num js-line-number" data-line-number="12"></td>
        <td id="LC12" class="blob-code js-file-line">  <span class="pl-s">var</span> modules <span class="pl-k">=</span> google.maps.modules <span class="pl-k">=</span> {};</td>
      </tr>
      <tr>
        <td id="L13" class="blob-num js-line-number" data-line-number="13"></td>
        <td id="LC13" class="blob-code js-file-line">  <span class="pl-s3">google.maps</span>.<span class="pl-en">__gjsload__</span> <span class="pl-k">=</span> <span class="pl-st">function</span>(<span class="pl-vpf">name</span>, <span class="pl-vpf">text</span>) {</td>
      </tr>
      <tr>
        <td id="L14" class="blob-num js-line-number" data-line-number="14"></td>
        <td id="LC14" class="blob-code js-file-line">    modules[name] <span class="pl-k">=</span> text;</td>
      </tr>
      <tr>
        <td id="L15" class="blob-num js-line-number" data-line-number="15"></td>
        <td id="LC15" class="blob-code js-file-line">  };</td>
      </tr>
      <tr>
        <td id="L16" class="blob-num js-line-number" data-line-number="16"></td>
        <td id="LC16" class="blob-code js-file-line">  </td>
      </tr>
      <tr>
        <td id="L17" class="blob-num js-line-number" data-line-number="17"></td>
        <td id="LC17" class="blob-code js-file-line">  <span class="pl-s3">google.maps</span>.<span class="pl-en">Load</span> <span class="pl-k">=</span> <span class="pl-st">function</span>(<span class="pl-vpf">apiLoad</span>) {</td>
      </tr>
      <tr>
        <td id="L18" class="blob-num js-line-number" data-line-number="18"></td>
        <td id="LC18" class="blob-code js-file-line">    <span class="pl-k">delete</span> google.maps.Load;</td>
      </tr>
      <tr>
        <td id="L19" class="blob-num js-line-number" data-line-number="19"></td>
        <td id="LC19" class="blob-code js-file-line">    apiLoad([0.009999999776482582,[[[&quot;http://mt0.googleapis.com/vt?lyrs=m@202000000\u0026src=api\u0026hl=en-US\u0026&quot;,&quot;http://mt1.googleapis.com/vt?lyrs=m@202000000\u0026src=api\u0026hl=en-US\u0026&quot;],null,null,null,null,&quot;m@202000000&quot;],[[&quot;http://khm0.googleapis.com/kh?v=122\u0026hl=en-US\u0026&quot;,&quot;http://khm1.googleapis.com/kh?v=122\u0026hl=en-US\u0026&quot;],null,null,null,1,&quot;122&quot;],[[&quot;http://mt0.googleapis.com/vt?lyrs=h@202000000\u0026src=api\u0026hl=en-US\u0026&quot;,&quot;http://mt1.googleapis.com/vt?lyrs=h@202000000\u0026src=api\u0026hl=en-US\u0026&quot;],null,null,&quot;imgtp=png32\u0026&quot;,null,&quot;h@202000000&quot;],[[&quot;http://mt0.googleapis.com/vt?lyrs=t@130,r@202000000\u0026src=api\u0026hl=en-US\u0026&quot;,&quot;http://mt1.googleapis.com/vt?lyrs=t@130,r@202000000\u0026src=api\u0026hl=en-US\u0026&quot;],null,null,null,null,&quot;t@130,r@202000000&quot;],null,[[null,0,7,7,[[[330000000,1246050000],[386200000,1293600000]],[[366500000,1297000000],[386200000,1314843700]]],[&quot;http://mt0.gmaptiles.co.kr/mt?v=kr1.17\u0026hl=en-US\u0026&quot;,&quot;http://mt1.gmaptiles.co.kr/mt?v=kr1.17\u0026hl=en-US\u0026&quot;]],[null,0,8,8,[[[330000000,1246050000],[386200000,1279600000]],[[345000000,1279600000],[386200000,1286700000]],[[354690000,1286700000],[386200000,1314843700]]],[&quot;http://mt0.gmaptiles.co.kr/mt?v=kr1.17\u0026hl=en-US\u0026&quot;,&quot;http://mt1.gmaptiles.co.kr/mt?v=kr1.17\u0026hl=en-US\u0026&quot;]],[null,0,9,9,[[[330000000,1246050000],[386200000,1279600000]],[[340000000,1279600000],[386200000,1286700000]],[[348900000,1286700000],[386200000,1302000000]],[[368300000,1302000000],[386200000,1314843700]]],[&quot;http://mt0.gmaptiles.co.kr/mt?v=kr1.17\u0026hl=en-US\u0026&quot;,&quot;http://mt1.gmaptiles.co.kr/mt?v=kr1.17\u0026hl=en-US\u0026&quot;]],[null,0,10,19,[[[329890840,1246055600],[386930130,1284960940]],[[344646740,1284960940],[386930130,1288476560]],[[350277470,1288476560],[386930130,1310531620]],[[370277730,1310531620],[386930130,1314843700]]],[&quot;http://mt0.gmaptiles.co.kr/mt?v=kr1.17\u0026hl=en-US\u0026&quot;,&quot;http://mt1.gmaptiles.co.kr/mt?v=kr1.17\u0026hl=en-US\u0026&quot;]],[null,3,7,7,[[[330000000,1246050000],[386200000,1293600000]],[[366500000,1297000000],[386200000,1314843700]]],[&quot;http://mt0.gmaptiles.co.kr/mt?v=kr1p.17\u0026hl=en-US\u0026&quot;,&quot;http://mt1.gmaptiles.co.kr/mt?v=kr1p.17\u0026hl=en-US\u0026&quot;]],[null,3,8,8,[[[330000000,1246050000],[386200000,1279600000]],[[345000000,1279600000],[386200000,1286700000]],[[354690000,1286700000],[386200000,1314843700]]],[&quot;http://mt0.gmaptiles.co.kr/mt?v=kr1p.17\u0026hl=en-US\u0026&quot;,&quot;http://mt1.gmaptiles.co.kr/mt?v=kr1p.17\u0026hl=en-US\u0026&quot;]],[null,3,9,9,[[[330000000,1246050000],[386200000,1279600000]],[[340000000,1279600000],[386200000,1286700000]],[[348900000,1286700000],[386200000,1302000000]],[[368300000,1302000000],[386200000,1314843700]]],[&quot;http://mt0.gmaptiles.co.kr/mt?v=kr1p.17\u0026hl=en-US\u0026&quot;,&quot;http://mt1.gmaptiles.co.kr/mt?v=kr1p.17\u0026hl=en-US\u0026&quot;]],[null,3,10,null,[[[329890840,1246055600],[386930130,1284960940]],[[344646740,1284960940],[386930130,1288476560]],[[350277470,1288476560],[386930130,1310531620]],[[370277730,1310531620],[386930130,1314843700]]],[&quot;http://mt0.gmaptiles.co.kr/mt?v=kr1p.17\u0026hl=en-US\u0026&quot;,&quot;http://mt1.gmaptiles.co.kr/mt?v=kr1p.17\u0026hl=en-US\u0026&quot;]]],[[&quot;http://cbk0.googleapis.com/cbk?&quot;,&quot;http://cbk1.googleapis.com/cbk?&quot;]],[[&quot;http://khm0.googleapis.com/kh?v=67\u0026hl=en-US\u0026&quot;,&quot;http://khm1.googleapis.com/kh?v=67\u0026hl=en-US\u0026&quot;],null,null,null,null,&quot;67&quot;],[[&quot;http://mt0.googleapis.com/mapslt?hl=en-US\u0026&quot;,&quot;http://mt1.googleapis.com/mapslt?hl=en-US\u0026&quot;]],[[&quot;http://mt0.googleapis.com/mapslt/ft?hl=en-US\u0026&quot;,&quot;http://mt1.googleapis.com/mapslt/ft?hl=en-US\u0026&quot;]],[[&quot;http://mt0.googleapis.com/vt?hl=en-US\u0026&quot;,&quot;http://mt1.googleapis.com/vt?hl=en-US\u0026&quot;]]],[&quot;en-US&quot;,&quot;US&quot;,null,0,null,null,&quot;http://maps.gstatic.com/mapfiles/&quot;,&quot;http://csi.gstatic.com&quot;,&quot;https://maps.googleapis.com&quot;,&quot;http://maps.googleapis.com&quot;],[&quot;http://maps.gstatic.com/intl/en_us/mapfiles/api-3/10/19&quot;,&quot;3.10.19&quot;],[1964956471],1.0,null,null,null,null,0,&quot;&quot;,null,null,0,&quot;http://khm.googleapis.com/mz?v=122\u0026&quot;,null,&quot;https://earthbuilder.google.com&quot;,&quot;https://earthbuilder.googleapis.com&quot;], loadScriptTime);</td>
      </tr>
      <tr>
        <td id="L20" class="blob-num js-line-number" data-line-number="20"></td>
        <td id="LC20" class="blob-code js-file-line">  };</td>
      </tr>
      <tr>
        <td id="L21" class="blob-num js-line-number" data-line-number="21"></td>
        <td id="LC21" class="blob-code js-file-line">  <span class="pl-s">var</span> loadScriptTime <span class="pl-k">=</span> (<span class="pl-k">new</span> <span class="pl-en">Date</span>).<span class="pl-s3">getTime</span>();</td>
      </tr>
      <tr>
        <td id="L22" class="blob-num js-line-number" data-line-number="22"></td>
        <td id="LC22" class="blob-code js-file-line">  getScript(<span class="pl-s1"><span class="pl-pds">&quot;</span>http://maps.gstatic.com/intl/en_us/mapfiles/api-3/10/19/main.js<span class="pl-pds">&quot;</span></span>);</td>
      </tr>
      <tr>
        <td id="L23" class="blob-num js-line-number" data-line-number="23"></td>
        <td id="LC23" class="blob-code js-file-line">})();</td>
      </tr>
</table>

  </div>

</div>

<a href="#jump-to-line" rel="facebox[.linejump]" data-hotkey="l" style="display:none">Jump to Line</a>
<div id="jump-to-line" style="display:none">
  <form accept-charset="UTF-8" class="js-jump-to-line-form">
    <input class="linejump-input js-jump-to-line-field" type="text" placeholder="Jump to line&hellip;" autofocus>
    <button type="submit" class="button">Go</button>
  </form>
</div>

        </div>

      </div><!-- /.repo-container -->
      <div class="modal-backdrop"></div>
    </div><!-- /.container -->
  </div><!-- /.site -->


    </div><!-- /.wrapper -->

      <div class="container">
  <div class="site-footer" role="contentinfo">
    <ul class="site-footer-links right">
        <li><a href="https://status.github.com/" data-ga-click="Footer, go to status, text:status">Status</a></li>
      <li><a href="https://developer.github.com" data-ga-click="Footer, go to api, text:api">API</a></li>
      <li><a href="https://training.github.com" data-ga-click="Footer, go to training, text:training">Training</a></li>
      <li><a href="https://shop.github.com" data-ga-click="Footer, go to shop, text:shop">Shop</a></li>
        <li><a href="https://github.com/blog" data-ga-click="Footer, go to blog, text:blog">Blog</a></li>
        <li><a href="https://github.com/about" data-ga-click="Footer, go to about, text:about">About</a></li>

    </ul>

    <a href="https://github.com" aria-label="Homepage">
      <span class="mega-octicon octicon-mark-github" title="GitHub"></span>
</a>
    <ul class="site-footer-links">
      <li>&copy; 2015 <span title="0.09846s from github-fe138-cp1-prd.iad.github.net">GitHub</span>, Inc.</li>
        <li><a href="https://github.com/site/terms" data-ga-click="Footer, go to terms, text:terms">Terms</a></li>
        <li><a href="https://github.com/site/privacy" data-ga-click="Footer, go to privacy, text:privacy">Privacy</a></li>
        <li><a href="https://github.com/security" data-ga-click="Footer, go to security, text:security">Security</a></li>
        <li><a href="https://github.com/contact" data-ga-click="Footer, go to contact, text:contact">Contact</a></li>
    </ul>
  </div>
</div>


    <div class="fullscreen-overlay js-fullscreen-overlay" id="fullscreen_overlay">
  <div class="fullscreen-container js-suggester-container">
    <div class="textarea-wrap">
      <textarea name="fullscreen-contents" id="fullscreen-contents" class="fullscreen-contents js-fullscreen-contents" placeholder=""></textarea>
      <div class="suggester-container">
        <div class="suggester fullscreen-suggester js-suggester js-navigation-container"></div>
      </div>
    </div>
  </div>
  <div class="fullscreen-sidebar">
    <a href="#" class="exit-fullscreen js-exit-fullscreen tooltipped tooltipped-w" aria-label="Exit Zen Mode">
      <span class="mega-octicon octicon-screen-normal"></span>
    </a>
    <a href="#" class="theme-switcher js-theme-switcher tooltipped tooltipped-w"
      aria-label="Switch themes">
      <span class="octicon octicon-color-mode"></span>
    </a>
  </div>
</div>



    
    

    <div id="ajax-error-message" class="flash flash-error">
      <span class="octicon octicon-alert"></span>
      <a href="#" class="octicon octicon-x flash-close js-ajax-error-dismiss" aria-label="Dismiss error"></a>
      Something went wrong with that request. Please try again.
    </div>


      <script crossorigin="anonymous" src="https://assets-cdn.github.com/assets/frameworks-70c417717c6c19f325c76c40de062c2e005f8cfec564283d7818b5b0fe8c0d27.js"></script>
      <script async="async" crossorigin="anonymous" src="https://assets-cdn.github.com/assets/github-9adb85255293205044bdded05300662b60a3fe712cb26ee7e5ca313a9f2ce3f7.js"></script>
      
      

  </body>
</html>

