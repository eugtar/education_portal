﻿using Domain;

namespace Presentation
{
    public interface IArticleUi
    {
        CreateArticleDto Create();
        UpdateArticleDto Update();
        string SelectOne();
        string Delete();
    }
}
