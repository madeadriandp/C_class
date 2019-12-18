using System.Dynamic;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace basic2
{
 
   class JsonData
    {
        static string input = @"[
  {
    'order_id': 'SO-921',
    'created_at': '2018-02-17T03:24:12',
    'customer': { 'id': 33, 'name': 'Ari' },
    'items': [
      { 'id': 24, 'name': 'Sapu Lidi', 'qty': 2, 'price': 13200 }, 
      { 'id': 73, 'name': 'Sprei 160x200 polos', 'qty': 1, 'price': 149000 }
    ]
  },
  {
    'order_id': 'SO-922',
    'created_at': '2018-02-20T13:10:32',
    'customer': { 'id': 40, 'name': 'Ririn' },
    'items': [
      { 'id': 83, 'name': 'Rice Cooker', 'qty': 1, 'price': 258000 },
      { 'id': 24, 'name': 'Sapu Lidi', 'qty': 1, 'price': 13200 }, 
      { 'id': 30, 'name': 'Teflon', 'qty': 1, 'price': 190000 }
    ]
  },
  {
    'order_id': 'SO-923',
    'created_at': '2018-02-28T15:20:43',
    'customer': { 'id': 33, 'name': 'Ari' },
    'items': [
      { 'id': 303, 'name': 'Pematik Api', 'qty': 1, 'price': 12000 }, 
      { 'id': 49, 'name': 'Panci', 'qty': 2, 'price': 70000 }
    ]
  },
  {
    'order_id': 'SO-924',
    'created_at': '2018-03-02T14:30:54',
    'customer': { 'id': 40, 'name': 'Ririn' },
    'items': [
      { 'id': 986, 'name': 'TV LCD 40 inch', 'qty': 1, 'price': 6000000 }
    ]
  },
  {
    'order_id': 'SO-925',
    'created_at': '2018-03-03T14:52:22',
    'customer': { 'id': 33, 'name': 'Ari' },
    'items': [
      { 'id': 1033, 'name': 'Nintendo Switch', 'qty': 1, 'price': 4990000 }, 
      { 'id': 2003, 'name': 'Macbook Air 11 inch 128 GB', 'qty': 1, 'price': 12000000 },
      { 'id': 23, 'name': 'Pocari Sweat 600ML', 'qty': 5, 'price': 7000 }
    ]
  },
  {
    'order_id': 'SO-926',
    'created_at': '2018-03-05T16:23:20',
    'customer': { 'id': 58, 'name': 'Annis' },
    'items': [
      { 'id': 24, 'name': 'Sapu Lidi', 'qty': 3, 'price': 13200 }
    ]
  }
]";
        public static void getJson() 
        {
            List<DataTransaksi> data = JsonConvert.DeserializeObject<List<DataTransaksi>>(input);
            
            foreach (var item in data)
            {
                Console.WriteLine(item.created_at);
            }           
        }
        public static void findFebruary()
        {
            List<DataTransaksi> data = JsonConvert.DeserializeObject<List<DataTransaksi>>(input);
            Console.WriteLine($"Order ID pesanan bulan february: ");
            foreach (var item in data)
            {
                if (item.created_at.Month == 2)
                {
                    Console.WriteLine(item.order_id);
                }
            }
        }
        public static void findAri()
        {
            List<DataTransaksi> data = JsonConvert.DeserializeObject<List<DataTransaksi>>(input);
            Console.WriteLine($"Order ID pesanan Ari: ");
            long total = 0;
            foreach (var item in data)
            {
                if (item.customer["name"] == "Ari")
                {
                    foreach (var list in item.items)
                    {
                        Console.WriteLine(list["price"]);
                        total = total + list["price"];
                    }
                    Console.WriteLine(item.order_id);
                }
            }
            Console.WriteLine($"Dengan total pembelian : {total}");
        }
        public static void grandTotalBelow300k()
        {
            List<DataTransaksi> data = JsonConvert.DeserializeObject<List<DataTransaksi>>(input);
            List<Pelanggan> users = new List<Pelanggan>();
            //init
            long tot = 0;
            foreach (var item in data[0].items)
            {
                tot = tot + item["price"];
            }
            Pelanggan pertama = new Pelanggan();
            pertama.name = data[0].customer["name"];
            pertama.total = tot;
            users.Add(pertama);
            for (int i = 1; i< data.Count;i++)
            {
                int penanda = 0;
                for (int j = 0; j < users.Count; j++)
                {
                    if(data[i].customer["name"] != users[j].name)
                    {
                        penanda++;
                        //Console.WriteLine("pelanggan baru");
                    }
                    else
                    {
                        long jumlah = 0;
                        foreach (var item in data[i].items)
                        {
                            jumlah = jumlah + item["price"];
                        }
                        users[j].total = users[j].total + jumlah;
                        //Console.WriteLine("pelanggan lama");
                    }
                    if(penanda == users.Count)// pelanggan baru
                    {
                        Pelanggan baru = new Pelanggan();
                        long jumlah = 0;
                        foreach (var item in data[i].items)
                        {
                            jumlah = jumlah + item["price"];
                        }
                        baru.name = data[i].customer["name"];
                        baru.total = jumlah;
                        users.Add(baru);
                    }
                }
            }
            Console.WriteLine("List Pembeli dan Total Belanjanya : ");
            for(int z = 0;z< users.Count;z++)
            {
                Console.WriteLine($"{z+1}. {users[z].name}, total belanja : {users[z].total}");
            }
            Console.WriteLine("Maka yang belanjanya kurang dari 300k adalah : ");
            for (int z = 0; z < users.Count; z++)
            {
                if (users[z].total < 300000)
                {
                    Console.WriteLine($"{z + 1}. {users[z].name}, total belanja : {users[z].total}");
                }
            }
        }
    }
    class Pelanggan
    {
        public string name { get; set; }
        public long total { get; set; }
    }
    class DataTransaksi
    {
        public string order_id { get; set; }
        public DateTime created_at { get; set; }
        public Dictionary<string, dynamic> customer { get; set; }
        public List<Dictionary<string, dynamic>> items { get; set; }
    }
}