using AutoMapper;
using Rooms_Booking.Models;
using Rooms_Booking.ViewModels.BookingViewModels;

namespace Rooms_Booking.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingListViewModel>()
             .ForMember(dest => dest.BookingID, opt => opt.MapFrom(src => src.ID))
             .ForMember(dest => dest.CheckInDate, opt => opt.MapFrom(src => src.CheckInDate))
             .ForMember(dest => dest.CheckOutDate, opt => opt.MapFrom(src => src.CheckOutDate))
             .ForMember(dest => dest.NumberOfRooms, opt => opt.MapFrom(src => src.NumberOfRooms))
             .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
             .ForMember(dest => dest.DiscountApplied, opt => opt.MapFrom(src => src.DiscountApplied))
             .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.HotelBranch.Name))
             .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.HotelBranch.Location));

            CreateMap<Booking, BookingDetailsViewModel>()
           .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Customer.City))
           .ForMember(dest => dest.NationalID, opt => opt.MapFrom(src => src.Customer.NID))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
           .ForMember(dest => dest.HasBookedPreviously, opt => opt.MapFrom(src => src.Customer.HasBookedPreviously))
           .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.HotelBranch.Name))
           .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.HotelBranch.Location));

        }
    }
}
