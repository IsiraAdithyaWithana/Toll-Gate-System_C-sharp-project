CREATE TABLE [dbo].[Violations]
(
	[Driver License] INT NOT NULL PRIMARY KEY, 
    [Select All] BIT NULL, 
    [Low Speed/inner lane] BIT NULL, 
    [Overspeed] BIT NULL, 
    [Not using seat belts] BIT NULL, 
    [Drunk driving] BIT NULL, 
    [Using mobile phones] BIT NULL, 
    [Invalid driver license] BIT NULL, 
    [Littering the road] BIT NULL, 
    [Collision during lane change] BIT NULL, 
    [Misuse E.Parklane] BIT NULL, 
    [Classless driver license] BIT NULL
)
