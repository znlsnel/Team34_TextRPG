using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
	public abstract class Scene
	{
		public string name;
		public Scene(string name) => this.name = name;
		public abstract void EnterScene();
	}
}
