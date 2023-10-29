CREATE TABLE [dbo].[Tasks] (
    [TaskId]      INT            IDENTITY (1, 1) NOT NULL,
    [TaskName]    NVARCHAR (255) NOT NULL,
    [CategoryId]  INT            NULL,
    [Deadline]    DATE           NULL,
    [IsCompleted] BIT            NULL,
    PRIMARY KEY CLUSTERED ([TaskId] ASC),
    CONSTRAINT [FK__Tasks__CategoryI__300424B4] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Llave Foránea que identifica el tipo de categoría que pertenece a la Tabla "dbo.Categories".', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tasks', @level2type = N'CONSTRAINT', @level2name = N'FK__Tasks__CategoryI__300424B4';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Clave primaria autoincremental para identificar de forma única cada tarea.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tasks', @level2type = N'COLUMN', @level2name = N'TaskId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Almacena el nombre de la tarea.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tasks', @level2type = N'COLUMN', @level2name = N'TaskName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Clave externa que referencia el "CategoryId" correspondiente en la tabla "dbo.Categories".', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tasks', @level2type = N'COLUMN', @level2name = N'CategoryId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Almacena la fecha límite de la tarea.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tasks', @level2type = N'COLUMN', @level2name = N'Deadline';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Valor booleano para indicar si la tarea está completada o no.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tasks', @level2type = N'COLUMN', @level2name = N'IsCompleted';

