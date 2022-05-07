using Military.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
        void AddPrivate(IPrivate priv);
    }
}
