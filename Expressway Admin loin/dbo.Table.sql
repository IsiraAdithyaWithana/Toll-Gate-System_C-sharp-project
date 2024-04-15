CREATE TABLE [dbo].[violations]
(
	[Driver lisence] INT NOT NULL PRIMARY KEY, 
    [Select All] BIT NULL, 
    [Low speed] BIT NULL, 
    [Over speed] BIT NULL, 
    [No seat belts] BIT NULL, 
    [Not signaling] BIT NULL, 
    [Driving under drugs] BIT NULL, 
    [Using mobile phone] BIT NULL, 
    [Littering roads] BIT NULL, 
    [Collision] BIT NULL, 
    [Misuse E.Parklane] BIT NULL
)
