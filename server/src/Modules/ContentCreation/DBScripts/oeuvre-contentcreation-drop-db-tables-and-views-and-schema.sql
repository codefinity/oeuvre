PRINT N'Droping Tables...';
PRINT N'Droping [contentcreation].[Members]...';
DROP TABLE IF EXISTS [contentcreation].[Members];

PRINT N'Droping [contentcreation].[Articles]...';
DROP TABLE IF EXISTS [contentcreation].[Articles];

PRINT N'Droping [contentcreation].[Collaborators]...';
DROP TABLE IF EXISTS [contentcreation].[Collaborators];

--PRINT N'Droping Views...';
--PRINT N'Droping View [contentcreation].[v_UserPermissions]...';
--DROP VIEW IF EXISTS [contentcreation].[v_UserPermissions]


PRINT N'Droping Schema...';
PRINT N'Droping Schema [contentcreation]...';
DROP SCHEMA IF EXISTS [contentcreation];