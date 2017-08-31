using System;
using System.Threading.Tasks;
using System.IO;
using Google.Protobuf;

using static ProtobufAddressBook.Person.Types;


namespace ProtobufAddressBook
{
    class Program
    {
        private static async Task<Person> PromptForPerson(TextReader input, TextWriter output)
        {
            Person person = new Person();
            await output.WriteAsync("Enter person Id: ");
            person.Id = int.Parse(await input.ReadLineAsync());

            await output.WriteAsync("Enter person name: ");
            person.Name = await input.ReadLineAsync();

            await output.WriteAsync("Enter person email address (blank for none): ");
            person.Email = await input.ReadLineAsync();

            return person;
        }

        public static async Task<int> Main(string[] args)
        {
            if (args.Length != 1)
            {
                await Console.Error.WriteLineAsync("Usage: Specify ADDRESS_BOOK_FILE");
                return 1;
            }

            AddressBook addressBook;

            if (File.Exists(args[0]))
            {
                using (Stream file = File.OpenRead(args[0]))
                {
                    addressBook = AddressBook.Parser.ParseFrom(file);
                }
            }
            else
            {
                addressBook = new AddressBook();
            }

            using (Stream file = File.OpenWrite(args[0]))
            {
                addressBook.WriteTo(file);
            }
            return 0;
        }
    }
}
