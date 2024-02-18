CREATE FUNCTION dbo.split
(
    @string VARCHAR(MAX),
    @separador VARCHAR(255)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS id,
        value
    FROM 
        OPENJSON('["' + REPLACE(@string, @separador, '","') + '"]')
)

--DROP FUNCTION split