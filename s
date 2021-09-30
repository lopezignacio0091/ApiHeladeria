[33mcommit 7c50e8b61a4fdf2154753a1d9c013e3e90c2cd4e[m[33m ([m[1;36mHEAD -> [m[1;32mmaster[m[33m, [m[1;31morigin/master[m[33m)[m
Author: Juan Ignacio Lopez <juan.lopez@indevelup.com>
Date:   Thu Sep 30 17:01:23 2021 -0300

    git inicial

[1mdiff --git a/.vs/ApiHeladeria/DesignTimeBuild/.dtbcache.v2 b/.vs/ApiHeladeria/DesignTimeBuild/.dtbcache.v2[m
[1mdeleted file mode 100644[m
[1mindex 2736d25..0000000[m
Binary files a/.vs/ApiHeladeria/DesignTimeBuild/.dtbcache.v2 and /dev/null differ
[1mdiff --git a/.vs/ApiHeladeria/config/applicationhost.config b/.vs/ApiHeladeria/config/applicationhost.config[m
[1mdeleted file mode 100644[m
[1mindex 9b329fc..0000000[m
[1m--- a/.vs/ApiHeladeria/config/applicationhost.config[m
[1m+++ /dev/null[m
[36m@@ -1,996 +0,0 @@[m
[31m-﻿<?xml version="1.0" encoding="UTF-8"?>[m
[31m-<!--[m
[31m-[m
[31m-    IIS configuration sections.[m
[31m-[m
[31m-    For schema documentation, see[m
[31m-    %IIS_BIN%\config\schema\IIS_schema.xml.[m
[31m-    [m
[31m-    Please make a backup of this file before making any changes to it.[m
[31m-[m
[31m-    NOTE: The following environment variables are available to be used[m
[31m-          within this file and are understood by the IIS Express.[m
[31m-[m
[31m-          %IIS_USER_HOME% - The IIS Express home directory for the user[m
[31m-          %IIS_SITES_HOME% - The default home directory for sites[m
[31m-          %IIS_BIN% - The location of the IIS Express binaries[m
[31m-          %SYSTEMDRIVE% - The drive letter of %IIS_BIN%[m
[31m-[m
[31m--->[m
[31m-<configuration>[m
[31m-  <!--[m
[31m-[m
[31m-        The <configSections> section controls the registration of sections.[m
[31m-        Section is the basic unit of deployment, locking, searching and[m
[31m-        containment for configuration settings.[m
[31m-        [m
[31m-        Every section belongs to one section group.[m
[31m-        A section group is a container of logically-related sections.[m
[31m-        [m
[31m-        Sections cannot be nested.[m
[31m-        Section groups may be nested.[m
[31m-        [m
[31m-        <section[m
[31m-            name=""  [Required, Collection Key] [XML name of the section][m
[31m-            allowDefinition="Everywhere" [MachineOnly|MachineToApplication|AppHostOnly|Everywhere] [Level where it can be set][m
[31m-            overrideModeDefault="Allow"  [Allow|Deny] [Default delegation mode][m
[31m-            allowLocation="true"  [true|false] [Allowed in location tags][m
[31m-        />[m
[31m-        [m
[31m-        The recommended way to unlock sections is by using a location tag:[m
[31m-        <location path="Default Web Site" overrideMode="Allow">[m
[31m-            <system.webServer>[m
[31m-                <asp />[m
[31m-            </system.webServer>[m
[31m-        </location>[m
[31m-[m
[31m-    -->[m
[31m-  <configSections>[m
[31m-    <sectionGroup name="system.applicationHost">[m
[31m-      <section name="applicationPools" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="configHistory" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="customMetadata" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="listenerAdapters" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="log" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="serviceAutoStartProviders" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="sites" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="webLimits" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-    </sectionGroup>[m
[31m-    <sectionGroup name="system.webServer">[m
[31m-      <section name="asp" overrideModeDefault="Deny" />[m
[31m-      <section name="caching" overrideModeDefault="Allow" />[m
[31m-      <section name="cgi" overrideModeDefault="Deny" />[m
[31m-      <section name="defaultDocument" overrideModeDefault="Allow" />[m
[31m-      <section name="directoryBrowse" overrideModeDefault="Allow" />[m
[31m-      <section name="fastCgi" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="globalModules" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-      <section name="handlers" overrideModeDefault="Deny" />[m
[31m-      <section name="httpCompression" overrideModeDefault="Allow" allowDefinition="Everywhere" />[m
[31m-      <section name="httpErrors" overrideModeDefault="Allow" />[m
[31m-      <section name="httpLogging" overrideModeDefault="Deny" />[m
[31m-      <section name="httpProtocol" overrideModeDefault="Allow" />[m
[31m-      <section name="httpRedirect" overrideModeDefault="Allow" />[m
[31m-      <section name="httpTracing" overrideModeDefault="Deny" />[m
[31m-      <section name="isapiFilters" allowDefinition="MachineToApplication" overrideModeDefault="Deny" />[m
[31m-      <section name="modules" allowDefinition="MachineToApplication" overrideModeDefault="Deny" />[m
[31m-      <section name="applicationInitialization" allowDefinition="MachineToApplication" overrideModeDefault="Allow" />[m
[31m-      <section name="odbcLogging" overrideModeDefault="Deny" />[m
[31m-      <sectionGroup name="security">[m
[31m-        <section name="access" overrideModeDefault="Deny" />[m
[31m-        <section name="applicationDependencies" overrideModeDefault="Deny" />[m
[31m-        <sectionGroup name="authentication">[m
[31m-          <section name="anonymousAuthentication" overrideModeDefault="Deny" />[m
[31m-          <section name="basicAuthentication" overrideModeDefault="Deny" />[m
[31m-          <section name="clientCertificateMappingAuthentication" overrideModeDefault="Deny" />[m
[31m-          <section name="digestAuthentication" overrideModeDefault="Deny" />[m
[31m-          <section name="iisClientCertificateMappingAuthentication" overrideModeDefault="Deny" />[m
[31m-          <section name="windowsAuthentication" overrideModeDefault="Deny" />[m
[31m-        </sectionGroup>[m
[31m-        <section name="authorization" overrideModeDefault="Allow" />[m
[31m-        <section name="ipSecurity" overrideModeDefault="Deny" />[m
[31m-        <section name="dynamicIpSecurity" overrideModeDefault="Deny" />[m
[31m-        <section name="isapiCgiRestriction" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />[m
[31m-        <section name="requestFiltering" overrideModeDefault="Allow" />[m
[31m-      </sectionGroup>[m
[31m-      <section name="serverRuntime" overrideModeDefault="Deny" />[m
[31m-      <section name="serverSideInclude" overrideModeDefault="Deny" />[m
[31m-      <section name="staticContent" overrideModeDefault="Allow" />[m
[31m-      <sectionGroup name="tracing">[m
[31m-        <section name="traceFailedRequests" overrideModeDefault="Allow" />[m
[31m-        <section name="traceProviderDefinitions" overrideModeDefault="Deny" />[m
[31m-      </sectionGroup>[m
[31m-      <section name="urlCompression" overrideModeDefault="Allow" />[m
[31m-      <section name="validation" overrideModeDefault="Allow" />[m
[31m-      <sectionGroup name="webdav">[m
[31m-        <section name="globalSettings" overrideModeDefault="Deny" />[m
[31m-        <section name="authoring" overrideModeDefault="Deny" />[m
[31m-        <section name="authoringRules" overrideModeDefault="Deny" />[m
[31m-      </sectionGroup>[m
[31m-      <sectionGroup name="rewrite">[m
[31m-        <section name="allowedServerVariables" overrideModeDefault="Deny" />[m
[31m-        <section name="rules" overrideModeDefault="Allow" />[m
[31m-        <section name="outboundRules" overrideModeDefault="Allow" />[m
[31m-        <section name="globalRules" overrideModeDefault="Deny" allowDefinition="AppHostOnly" />[m
[31m-        <section name="providers" overrideModeDefault="Allow" />[m
[31m-        <sectio