using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStackExercise.Data.Model;

namespace FullStackExercise.Business.Infrastructure
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
