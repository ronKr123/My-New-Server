﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenreList: List<Genre>
    {
		public GenreList() : base() { }

		public GenreList(IEnumerable<Genre> list) : base(list) { }

		public GenreList(IEnumerable<BaseEntity> list) : base(list.OfType<Genre>()) { }


	}
}
